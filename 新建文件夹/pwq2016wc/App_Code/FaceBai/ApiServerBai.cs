using Baidu.Aip.Face;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceBai
{
    //http://ai.baidu.com/docs#/Face-Csharp-SDK/274b74c0
    public class ApiServerBai
    {
        private string apiid = "15636581";
        private string apikey = "UqekrUZZ57q7GYGyAYqkbgHn";
        private string apisecret = "GEu8C2cmM3aR8h2sE4Wt00naO7fwRKlL ";

        private string groupid = "FaceAnHeng";

        public Face client;

        public static bool NormalErrorCode(string code)
        {
            if (code == "222207") return true;

            return false;
        }

        public JObject faceSearch(string base64, int max_user_num = 2)
        {
            var options = new Dictionary<string, object>{
                {"max_user_num",max_user_num}
            };

            return client.Search(base64, "BASE64", groupid, options);
        }

        public JObject faceGroupAddUser(string base64, string uid, string uinfo)
        {
            var options = new Dictionary<string, object>{
                {"user_info",uinfo}
            };

            return client.UserAdd(base64, "BASE64", groupid, uid, options);
        }


        public ApiServerBai()
        {
            client = new Face(apikey, apisecret);
        }

        /// <summary>
        /// 人脸检测
        /// </summary>
        public JObject faceDetect(byte[] imageBytes, int max_face_num = 1, string face_field = "age")
        {
            var options = new Dictionary<string, object>
            {
	            {"max_face_num", max_face_num},
	            {"face_field", face_field}
            };

            return client.Detect(Convert.ToBase64String(imageBytes), "BASE64", options);
        }


        /// <summary>
        /// 人脸对比
        /// </summary>
        public JObject faceCompare(byte[] imageBytes, byte[] imageBytes2)
        {
            try
            {
                JArray[] jarrt = new JArray[2];
                string str = "[{\"image\":\"" + Convert.ToBase64String(imageBytes) + "\",\"image_type\":\"BASE64\"},{\"image\":\"" + Convert.ToBase64String(imageBytes2) + "\",\"image_type\":\"BASE64\"}]";

                return client.Match(JArray.Parse(str));
            }
            catch
            {

            }

            return getError();
        }

        /// <summary>
        /// 人脸识别
        /// </summary>
        /// <param name="imageBytes"></param>
        /// <param name="user_top_num"></param>
        /// <returns></returns>
        public JObject faceSearch(byte[] imageBytes, int max_user_num = 2)
        {
            var options = new Dictionary<string, object>{
                {"max_user_num",max_user_num}
            };

            return client.Search(Convert.ToBase64String(imageBytes), "BASE64", groupid, options);
        }

        

        /// <summary>
        /// 组内添加一个用户
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="uinfo"></param>
        /// <param name="imageBytes"></param>
        /// <returns></returns>
        //public JObject faceGroupAddUser(string uid,string uinfo,byte[] imageBytes)
        //{
        //    var options = new Dictionary<string, object>{
        //        {"action_type", "replace"}
        //    };

        //    return client.UserAdd(uid, uinfo, groupid, imageBytes, options);
        //}

        public JObject faceGroupAddUser(byte[] imageBytes, string uid, string uinfo)
        {
            var options = new Dictionary<string, object>{
                {"user_info",uinfo}
            };

            return client.UserAdd(Convert.ToBase64String(imageBytes), "BASE64", groupid, uid, options);
        }

        /// <summary>
        /// 组内移除某个用户
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public JObject faceGroupRemoveUser(string uid)
        {
            var options = new Dictionary<string, object>
            {
            };

            return client.UserDelete(groupid, uid, options);
        }

        /// <summary>
        /// 获取用户个人信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public JObject faceDetail(string uid)
        {
            var options = new Dictionary<string, object>
            {
            };

            return client.UserGet(uid, groupid, options);
        }

        /// <summary>
        /// 组列表查询
        /// </summary>
        /// <returns></returns>
        public JObject faceGroups()
        {
            return client.GroupGetlist();
        }

        /// <summary>
        /// 组内用户列表查询
        /// </summary>
        /// <returns></returns>
        public JObject faceGroupDetail(int start = 0, int num = 100)
        {
            var options = new Dictionary<string, object>{
	            {"start", 0},
	            {"num", 50}
	        };

            return client.GroupGetusers(groupid, options);
        }

        public JObject getError()
        {
            return (JsonConvert.DeserializeObject("{\"error_code\": 1000,\"log_id\": 0,\"error_msg\": \"plusnet error\"}") as JObject);
        }
    }
}
