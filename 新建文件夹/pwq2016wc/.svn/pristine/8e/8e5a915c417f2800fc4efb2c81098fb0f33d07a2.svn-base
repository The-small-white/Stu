using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateEngine
{
    public class StringDeal
    {
        /// <summary>
        /// 首字母大写，其他小写
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string HeadUpper(string word)
        {
            //空的话就返回空
            if (string.IsNullOrEmpty(word)) return string.Empty;

            string headWord = word.Substring(0, 1);  //第一个字符
            string otherWord = word.Substring(1);
            //otherWord = otherWord.ToLower(); //获取全小写
            headWord = headWord.ToUpper(); //获取全大写

            string newWord = headWord + otherWord;
            return newWord;

        }

        public static string HeadLower(string word)
        {
            //空的话就返回空
            if (string.IsNullOrEmpty(word)) return string.Empty;

            string headWord = word.Substring(0, 1);  //第一个字符
            string otherWord = word.Substring(1);
            //otherWord = otherWord.ToLower(); //获取全小写
            headWord = headWord.ToLower(); //获取全大写

            string newWord = headWord + otherWord;
            return newWord;

        }

        /// <summary>
        /// 根据连个字符串截取字符串
        /// </summary>
        /// <param name="str">初始字符串</param>
        /// <param name="beginStr"></param>
        /// <param name="endStr"></param>
        /// <returns></returns>
        public static string CutString(string str, string beginStr, string endStr)
        {
            int begin = str.IndexOf(beginStr);
            int end = str.IndexOf(endStr);

            if (begin == -1 || end == -1) { return ""; }

            begin = begin + beginStr.Length;
           return str.Substring(begin, end - begin);
        }
    }
}
