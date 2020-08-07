using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

  /// <summary>
    /// ��֤��ģ��
    /// </summary>
    public class CreateImage
    {
        public static void DrawImage()
        {
            CreateImage img = new CreateImage();
            HttpContext.Current.Session["CheckCode"] = img.RndNum(4);
            img.CreateImages(HttpContext.Current.Session["CheckCode"].ToString());
        }

        /// <summary>
        /// ������֤ͼƬ
        /// </summary>
        /// <param name="checkCode">��֤�ַ�</param>
        private void CreateImages(string checkCode)
        {
            int iwidth = (int)(checkCode.Length * 13);
            System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 20);
            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.White);
            //������ɫ
            Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
            //��������            
            string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "����" };
            Random rand = new Random();
            //���������
            for (int i = 0; i < 50; i++)
            {
                int x = rand.Next(image.Width);
                int y = rand.Next(image.Height);
                g.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
            }

            //�����ͬ�������ɫ����֤���ַ�
            for (int i = 0; i < checkCode.Length; i++)
            {
                int cindex = rand.Next(7);
                int findex = rand.Next(5);

                Font f = new System.Drawing.Font(font[findex], 10, System.Drawing.FontStyle.Bold);
                Brush b = new System.Drawing.SolidBrush(c[cindex]);
                int ii = 4;
                if ((i + 1) % 2 == 0)
                {
                    ii = 2;
                }
                g.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * 12), ii);
            }
            //��һ���߿�
            g.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);

            //����������
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            HttpContext.Current.Response.ClearContent();
            //Response.ClearContent();
            HttpContext.Current.Response.ContentType = "image/Jpeg";
            HttpContext.Current.Response.BinaryWrite(ms.ToArray());
            g.Dispose();
            image.Dispose();
        }

        /// <summary>
        /// �����������ĸ
        /// </summary>
        /// <param name="VcodeNum">������ĸ�ĸ���</param>
        /// <returns>string</returns>
        private string RndNum(int VcodeNum)
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9";
            string[] VcArray = Vchar.Split(',');
            string VNum = "";   //�����ַ����̣ܶ��Ͳ���StringBuilder��
            int temp = -1;       //��¼�ϴ������ֵ������������������һ���������

            //����һ���򵥵��㷨�Ա�֤����������Ĳ�ͬ
            Random rand = new Random();
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(VcArray.Length);
                if (temp != -1 && temp == t)
                {
                    return RndNum(VcodeNum);
                }
                temp = t;
                VNum += VcArray[t];

            }
            return VNum;
        }

     
        ///<summary>  
        /// ��������ͼ   
        /// </summary>   
        /// <param name="stream">ԭͼstream</param>   
        /// <param name="thumbnailPath">����ͼ·��</param>   
        /// <param name="width">����ͼ���</param>   
        /// <param name="height">����ͼ�߶�</param>   
        /// <param name="mode">��������ͼ�ķ�ʽ:HWָ���߿�����(���ܱ���);Wָ�����߰����� Hָ���ߣ������� Cutָ���߿�ü�(������)</param>����   
        /// <param name="imageType">Ҫ����ͼ����ĸ�ʽ(gif,jpg,bmp,png) Ϊ�ջ�δ֪���Ͷ���Ϊjpg</param>����   
        public void CreateThumbnail(Stream stream, string thumbnailPath, int width, int height, string mode, string imageType)
        {
            Image originalImage = Image.FromStream(stream);
            CreateThumbnail(originalImage, thumbnailPath, width, height, mode, imageType);
        }

        ///<summary>  
        /// ��������ͼ   
        /// </summary>   
        /// <param name="originalImagePath">Դͼ·��</param>   
        /// <param name="thumbnailPath">����ͼ·��</param>   
        /// <param name="width">����ͼ���</param>   
        /// <param name="height">����ͼ�߶�</param>   
        /// <param name="mode">��������ͼ�ķ�ʽ:HWָ���߿�����(���ܱ���);Wָ�����߰����� Hָ���ߣ������� Cutָ���߿�ü�(������)</param>����   
        /// <param name="imageType">Ҫ����ͼ����ĸ�ʽ(gif,jpg,bmp,png) Ϊ�ջ�δ֪���Ͷ���Ϊjpg</param>����   
        public void CreateThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode, string imageType)
        {
            Image originalImage = Image.FromFile(originalImagePath);
            CreateThumbnail(originalImage, thumbnailPath, width, height, mode, imageType);
        }

        ///<summary>  
        /// ��������ͼ   
        /// </summary>   
        /// <param name="originalImagePath">Դͼ·��</param>   
        /// <param name="thumbnailPath">����ͼ·��</param>   
        /// <param name="width">����ͼ���</param>   
        /// <param name="height">����ͼ�߶�</param>   
        /// <param name="mode">��������ͼ�ķ�ʽ:HWָ���߿�����(���ܱ���);Wָ�����߰����� Hָ���ߣ������� Cutָ���߿�ü�(������)</param>����   
        /// <param name="imageType">Ҫ����ͼ����ĸ�ʽ(gif,jpg,bmp,png) Ϊ�ջ�δ֪���Ͷ���Ϊjpg</param>����   
        private void CreateThumbnail(Image originalImage, string thumbnailPath, int width, int height, string mode, string imageType)
        {
            int towidth = width;
            int toheight = height;
            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;
            switch (mode)
            {
                case "HW"://ָ���߿����ţ����ܱ��Σ�����������������   
                    break;
                case "W"://ָ�����߰�������������������������   
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://ָ���ߣ�������   
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://ָ���߿�ü��������Σ�����������������   
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }
            //�½�һ��bmpͼƬ   
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);
            //�½�һ������   
            Graphics g = System.Drawing.Graphics.FromImage(bitmap);
            //���ø�������ֵ��   
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //���ø�����,���ٶȳ���ƽ���̶�   
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //��ջ�������͸������ɫ���   
            g.Clear(Color.Transparent);
            //��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������   
            g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
               new Rectangle(x, y, ow, oh),
               GraphicsUnit.Pixel);
            try
            {

                //��jpg��ʽ��������ͼ   
                switch (imageType.ToLower())
                {
                    case "gif":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "jpg":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "bmp":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "png":
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                        bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
    }

