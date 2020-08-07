using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateEngine
{
    public class StringDeal
    {
        /// <summary>
        /// ����ĸ��д������Сд
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public static string HeadUpper(string word)
        {
            //�յĻ��ͷ��ؿ�
            if (string.IsNullOrEmpty(word)) return string.Empty;

            string headWord = word.Substring(0, 1);  //��һ���ַ�
            string otherWord = word.Substring(1);
            //otherWord = otherWord.ToLower(); //��ȡȫСд
            headWord = headWord.ToUpper(); //��ȡȫ��д

            string newWord = headWord + otherWord;
            return newWord;

        }

        public static string HeadLower(string word)
        {
            //�յĻ��ͷ��ؿ�
            if (string.IsNullOrEmpty(word)) return string.Empty;

            string headWord = word.Substring(0, 1);  //��һ���ַ�
            string otherWord = word.Substring(1);
            //otherWord = otherWord.ToLower(); //��ȡȫСд
            headWord = headWord.ToLower(); //��ȡȫ��д

            string newWord = headWord + otherWord;
            return newWord;

        }

        /// <summary>
        /// ���������ַ�����ȡ�ַ���
        /// </summary>
        /// <param name="str">��ʼ�ַ���</param>
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
