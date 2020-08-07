using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateEngine
{
   public class TypeDeal
    {
        public static TypeUnit Convert(string sqlTypeWord)
        {
            TypeUnit typeUnit = new TypeUnit();
            string word = "";
            if (sqlTypeWord.Contains("(") && sqlTypeWord.Contains(")"))//找到（）时候代表有长度限制
            {
                int begin = sqlTypeWord.LastIndexOf("(");
                int end = sqlTypeWord.LastIndexOf(")");
                string lengthStr = sqlTypeWord.Substring(begin + 1, end - begin - 1);
                if (lengthStr == "MAX")
                {
                    typeUnit.Length = -1;
                }
                else
                {
                    if (sqlTypeWord.Contains(","))
                    {
                        int newEnd = sqlTypeWord.LastIndexOf(",");
                        lengthStr = sqlTypeWord.Substring(begin + 1, newEnd - begin - 1);
                    }
                    typeUnit.Length = System.Convert.ToInt32(lengthStr);
                }
                
                word = sqlTypeWord.Substring(0, begin); //获取数据类型单词
                
            }
            else
            {
                typeUnit.Length = -1;
                word = sqlTypeWord;
            }
            //word = word.ToLower();
            switch (word) // 根据单词判断类型
            {
                #region case
                case "bigint":  //长整型
                    typeUnit.NetType = "long";
                    typeUnit.SqlType = "BigInt";
                    typeUnit.ConvertString = "ToInt64";
                    break;

                case "binary":  //
                    typeUnit.NetType = "Byte[]";
                    typeUnit.SqlType = "Binary";
                    typeUnit.ConvertString = "ToBase64CharArray";
                    //Convert.ToBase64CharArray(
                    break;
                    //Byte[] asd = new Byte[];
                    
                case "bit":
                    typeUnit.NetType = "Boolean";
                    typeUnit.SqlType = "Bit";
                    typeUnit.ConvertString = "ToBoolean";

                    break;

                case "char":
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "Char";
                    typeUnit.ConvertString = "ToString";

                    break;

                case "datetime":
                    typeUnit.NetType = "DateTime";
                    typeUnit.SqlType = "DateTime";
                    typeUnit.ConvertString = "ToDateTime";

                    break;

                case "decimal":
                    typeUnit.NetType = "decimal";
                    typeUnit.SqlType = "Decimal";
                    typeUnit.ConvertString = "ToDecimal";

                    break;

                case "float":
                    typeUnit.NetType = "double";
                    typeUnit.SqlType = "Float";
                    typeUnit.ConvertString = "ToDouble";

                    break;

                case "image":  //
                    typeUnit.NetType = "Byte[]";
                    typeUnit.SqlType = "Binary";
                    typeUnit.ConvertString = "ToBase64CharArray";
                    //Convert.ToBase64CharArray(
                    break;


                case "int":
                    typeUnit.NetType = "int";
                    typeUnit.SqlType = "Int";
                    typeUnit.ConvertString = "ToInt32";

                    break;

                case "money":
                    typeUnit.NetType = "Single";
                    typeUnit.SqlType = "Money";
                    typeUnit.ConvertString = "ToSingle";

                    break;

                case "nchar":
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "NChar";
                    typeUnit.ConvertString = "ToString";

                    break;

                case "smallmoney":
                    typeUnit.NetType = "Single";
                    typeUnit.SqlType = "SmallMoney";
                    typeUnit.ConvertString = "ToSingle";

                    break;

                case "numeric":
                    typeUnit.NetType = "decimal";
                    typeUnit.SqlType = "Decimal";
                    typeUnit.ConvertString = "ToDecimal";

                    break;

                case "real":
                    typeUnit.NetType = "UInt32";
                    typeUnit.SqlType = "Real";
                    typeUnit.ConvertString = "ToUInt32";

                    break;

                case "smalldatetime":
                    typeUnit.NetType = "DateTime";
                    typeUnit.SqlType = "SmallDateTime";
                    typeUnit.ConvertString = "ToDateTime";

                    break;
                case "smallint":
                    typeUnit.NetType = "smallint";
                    typeUnit.SqlType = "SmallInt";
                    typeUnit.ConvertString = "ToInt16";

                    break;

                case "text":
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "Text";
                    typeUnit.ConvertString = "ToString";

                    break;

                case "uniqueidentifier":
                    typeUnit.NetType = "Guid";
                    typeUnit.SqlType = "UniqueIdentifier";
                    typeUnit.ConvertString = "Guid";

                    break;

                case "varchar":
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "VarChar";
                    typeUnit.ConvertString = "ToString";

                    break;


                case "ntext":
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "NText";
                    typeUnit.ConvertString = "ToString";

                    break;

                case "nvarchar":
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "NVarChar";
                    typeUnit.ConvertString = "ToString";

                    break;


                default:
                    typeUnit.NetType = "string";
                    typeUnit.SqlType = "VarChar";
                    typeUnit.ConvertString = "ToString";

                    break;
                //System.Convert.
                #endregion
            }
            return typeUnit;
        }
    }

    public class TypeUnit
    {
        #region 内部变量
        private string netType;// 在net里的类型字符串
        private string sqlType;// 在sql2005里的类型字符串
        private string convertString;// 强制转化的字符串方法  
        private int length = -1;// 长度限制  ,-1代表不限制
        #endregion

        public string NetType
        {
            get
            {
                return netType;
            }
            set
            {
                netType = value;
            }
        }

        public string SqlType
        {
            get
            {
                return sqlType;
            }
            set
            {
                sqlType = value;
            }
        }

        public string ConvertString
        {
            get
            {
                return convertString;
            }
            set
            {
                convertString = value;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
    }


}
