using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace FaceBai
{
    public static class HttpHelper4MultipartForm
    {
        public class FileParameter
        {
            public byte[] File
            {
                get;
                set;
            }

            public string FileName
            {
                get;
                set;
            }

            public string ContentType
            {
                get;
                set;
            }

            public FileParameter(byte[] file)
                : this(file, null)
            {
            }

            public FileParameter(byte[] file, string filename)
                : this(file, filename, null)
            {
            }

            public FileParameter(byte[] file, string filename, string contenttype)
            {
                this.File = file;
                this.FileName = filename;
                this.ContentType = contenttype;
            }
        }

        private static readonly Encoding encoding = Encoding.UTF8;

        public static HttpWebResponse MultipartFormDataPost(string postUrl, string userAgent, Dictionary<string, object> postParameters)
        {
            string text = string.Format("----------{0:N}", Guid.NewGuid());
            string contentType = "multipart/form-data; boundary=" + text;
            byte[] multipartFormData = HttpHelper4MultipartForm.GetMultipartFormData(postParameters, text);

            return HttpHelper4MultipartForm.PostForm(postUrl, userAgent, contentType, multipartFormData);
        }

        private static HttpWebResponse PostForm(string postUrl, string userAgent, string contentType, byte[] formData)
        {
            ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

            

            HttpWebRequest httpWebRequest = WebRequest.Create(postUrl) as HttpWebRequest;
            if (httpWebRequest == null)
            {
                throw new NullReferenceException("request is not a http request");
            }

            //ServicePointManager.SecurityProtocol = (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls);
            //ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(HttpHelper4MultipartForm.CheckValidationResult);
            httpWebRequest.Method = "POST";
            httpWebRequest.SendChunked = false;
            httpWebRequest.KeepAlive = true;
            httpWebRequest.Proxy = null;
            httpWebRequest.Timeout = Timeout.Infinite;
            httpWebRequest.ReadWriteTimeout = Timeout.Infinite;
            httpWebRequest.AllowWriteStreamBuffering = false;
            httpWebRequest.ProtocolVersion = HttpVersion.Version11;
            httpWebRequest.ContentType = contentType;
            //httpWebRequest.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1.5) Gecko/20091102 Firefox/3.5.5 GTB6";
            httpWebRequest.CookieContainer = new CookieContainer();
            //if (!string.IsNullOrEmpty(cookie))
            //{
            //    httpWebRequest.CookieContainer = new CookieContainer();
            //    string[] cookieParts = cookie.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
            //    httpWebRequest.CookieContainer.Add(new Cookie(cookieParts[0].Substring(0, cookieParts[0].IndexOf("=")), cookieParts[0].Substring(cookieParts[0].IndexOf("=") + 1), "/", domain));
            //}
            httpWebRequest.ContentLength = (long)formData.Length;

            
            try
            {
                using (Stream requestStream = httpWebRequest.GetRequestStream())
                {
                    int bufferSize = 4096;
                    int position = 0;
                    while (position < formData.Length)
                    {
                        bufferSize = Math.Min(bufferSize, formData.Length - position);

                        byte[] data = new byte[bufferSize];
                        Array.Copy(formData, position, data, 0, bufferSize);
                        requestStream.Write(data, 0, data.Length);
                        position += data.Length;
                    }
                    //requestStream.Write(formData, 0, formData.Length);
                    requestStream.Close();
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            HttpWebResponse result;
            try
            {
                result = (httpWebRequest.GetResponse() as HttpWebResponse);
            }
            catch (WebException arg_9C_0)
            {
                result = (arg_9C_0.Response as HttpWebResponse);
            }
            return result;
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
        {
            Stream stream = new MemoryStream();
            bool flag = false;
            foreach (KeyValuePair<string, object> current in postParameters)
            {
                if (flag)
                {
                    stream.Write(HttpHelper4MultipartForm.encoding.GetBytes("\r\n"), 0, HttpHelper4MultipartForm.encoding.GetByteCount("\r\n"));
                }
                flag = true;
                if (current.Value is HttpHelper4MultipartForm.FileParameter)
                {
                    HttpHelper4MultipartForm.FileParameter fileParameter = (HttpHelper4MultipartForm.FileParameter)current.Value;
                    string s = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n", new object[]
                    {
                        boundary,
                        current.Key,
                        fileParameter.FileName ?? current.Key,
                        fileParameter.ContentType ?? "application/octet-stream"
                    });
                    stream.Write(HttpHelper4MultipartForm.encoding.GetBytes(s), 0, HttpHelper4MultipartForm.encoding.GetByteCount(s));
                    stream.Write(fileParameter.File, 0, fileParameter.File.Length);
                }
                else
                {
                    string s2 = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}", boundary, current.Key, current.Value);
                    stream.Write(HttpHelper4MultipartForm.encoding.GetBytes(s2), 0, HttpHelper4MultipartForm.encoding.GetByteCount(s2));
                }
            }
            string s3 = "\r\n--" + boundary + "--\r\n";
            stream.Write(HttpHelper4MultipartForm.encoding.GetBytes(s3), 0, HttpHelper4MultipartForm.encoding.GetByteCount(s3));
            stream.Position = 0L;
            byte[] array = new byte[stream.Length];
            stream.Read(array, 0, array.Length);

            stream.Close();

            return array;
        }

        public static bool MyRemoteCertificateValidationCallback(System.Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            bool isOk = true;
            // If there are errors in the certificate chain, look at each error to determine the cause.
            if (sslPolicyErrors != SslPolicyErrors.None)
            {
                for (int i = 0; i < chain.ChainStatus.Length; i++)
                {
                    if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
                    {
                        chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                        chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                        chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                        chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                        bool chainIsValid = chain.Build((X509Certificate2)certificate);
                        if (!chainIsValid)
                        {
                            isOk = false;
                        }
                    }
                }
            }
            return isOk;
        }
    }
}
