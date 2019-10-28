using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ERPApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public static class ExtensionService
    {
        /// <summary>
        ///  将Request传入的Entity与原始Entity进行比较并合并
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbEntity">原始Entity</param>
        /// <param name="reqEntity">由Request传入的Entity</param>
        /// <returns></returns>
        public static TEntity MergeFrom<TEntity>(this TEntity dbEntity, TEntity reqEntity)
        {
            if (reqEntity.GetType() == dbEntity.GetType())
            {
                PropertyInfo[] properties = dbEntity.GetType().GetProperties();

                foreach (var p in properties)
                {
                    var reqEntityValue = p.GetValue(reqEntity, null);
                    if (reqEntityValue != null)
                    {
                        if (p.IsMapped())
                        {
                            if (reqEntityValue != GetDefault(p.GetType()))
                            {
                                p.SetValue(dbEntity, reqEntityValue, null);
                            }
                        }
                    }
                }
            }
            return dbEntity;
        }

        /// <summary>
        /// 判断属性是否有效，即能否存入数据库
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool IsMapped(this PropertyInfo p)
        {
            return p.CustomAttributes.Where(x => x.AttributeType.Name == "NotMappedAttribute").ToList().Count == 0;
        }

        private static object GetDefault(Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        #region RMB 大小写转换

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static String ConvertToChinese(Decimal number)
        {
            var s = number.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
            var d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
            var r = Regex.Replace(d, ".", m => "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟万亿兆京垓秭穰"[m.Value[0] - '-'].ToString());
            return r;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvMoney(double input)
        {
            var minusMark = false;
            if (input == 0)
            {
                return "零";
            }
            if (input < 0)
            {
                input = input * -1;
                minusMark = true;
            }
            string result = "";
            string tmpResult;
            input *= 100;
            input = Convert.ToUInt64(input);
            tmpResult = input.ToString();
            for (int i = 0; i < tmpResult.Length; i++)
            {
                string tmpChar = tmpResult.Substring(tmpResult.Length - 1 - i, 1);
                if (i == 0 && tmpChar == "0")
                {
                    continue;
                }
                else if (i == 1 && tmpChar == "0")
                {
                    continue;
                }
                result = Upper(tmpChar) + Unit(i) + result;
            }
            StringBuilder sb = new StringBuilder();
            sb.Append(result.Substring(0, 1));
            for (int m = 1; m < result.Length; m++)
            {
                if (result.Substring(m, 1) != result.Substring(m - 1, 1))
                {
                    sb.Append(result.Substring(m, 1));
                }
            }
            result = sb.ToString();

            if (result.Substring(result.Length - 1, 1) == "零")
            {
                sb.Replace("零", "元", result.Length - 1, 1);
            }
            else if ((result.Substring(result.Length - 1, 1) == "角" && result.Substring(result.Length - 3, 1) == "零") || (result.Substring(result.Length - 1, 1) == "分" && result.Substring(result.Length - 3, 1) == "零"))
            {
                sb.Replace("零", "元", result.Length - 3, 1);
            }
            else if (result.Substring(result.Length - 1, 1) == "分" && result.Substring(result.Length - 3, 1) == "角" && result.Substring(result.Length - 5, 1) == "零")
            {
                sb.Replace("零", "元", result.Length - 5, 1);
            }
            result = sb.ToString();
            result = result.Replace("零仟", "零");
            result = result.Replace("零佰", "零");
            result = result.Replace("零拾", "零");
            while (true)
            {
                if (result.IndexOf("零零") == -1)
                {
                    break;
                }
                result = result.Replace("零零", "零");
            }
            result = result.Replace("零亿", "亿");
            result = result.Replace("零万", "万");
            result = result.Replace("零元", "元");
            result = result.Replace("亿万", "亿");
            if (minusMark)
            {
                result = "负" + result;
            }
            return result;
        }
        /// <summary>
        /// 小写转换为大写
        /// </summary>
        /// <param name="strBefore"></param>
        /// <returns></returns>
        private static string Upper(string strBefore)
        {
            string strAfter = null;
            switch (strBefore)
            {
                case "0":
                    strAfter = "零";
                    break;
                case "1":
                    strAfter = "壹";
                    break;
                case "2":
                    strAfter = "贰";
                    break;
                case "3":
                    strAfter = "叁";
                    break;
                case "4":
                    strAfter = "肆";
                    break;
                case "5":
                    strAfter = "伍";
                    break;
                case "6":
                    strAfter = "陆";
                    break;
                case "7":
                    strAfter = "柒";
                    break;
                case "8":
                    strAfter = "捌";
                    break;
                case "9":
                    strAfter = "玖";
                    break;
            }
            return strAfter;
        }
        /// <summary>
        /// 得到货币单位
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static string Unit(int i)
        {
            string strUnit = "";
            if (i == 0)
            {
                strUnit = "分";
            }
            else if (i == 1)
            {
                strUnit = "角";
            }
            else
            {
                i -= 2;
                if (i / 4 == 0 && i % 4 == 0)
                {
                    strUnit = "元";
                }
                else if (i / 4 == 1 && i % 4 == 0)
                {
                    strUnit = "万";
                }
                else if (i / 4 == 2 && i % 4 == 0)
                {
                    strUnit = "亿";
                }
                else if (i / 4 > 2 && i % 4 == 0)
                {
                    for (int j = 0; j < i / 4; j++)
                    {
                        strUnit += "万";
                    }
                    strUnit += "亿";
                }
                else
                {
                    strUnit = GetBit(i % 4);
                }
            }
            return strUnit;
        }
        /// <summary>
        /// 得到位数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private static string GetBit(int i)
        {
            string strBit = "";
            switch (i)
            {
                case 1:
                    strBit = "拾";
                    break;
                case 2:
                    strBit = "佰";
                    break;
                case 3:
                    strBit = "仟";
                    break;
            }
            return strBit;
        }
        #endregion 
    }
}