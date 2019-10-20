using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ERPApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class EncryptHelper
    {
        /// <summary>
        /// 获取某个哈希算法对应下的哈希值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="algorithm">哈希算法</param>
        /// <returns>经过计算的哈希值</returns>
        private static string GetHash(string sourceString, HashAlgorithm algorithm)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(sourceString);
            byte[] result = algorithm.ComputeHash(sourceBytes);
            algorithm.Clear();
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < result.Length; i++)
            {
                sb.Append(result[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取MD5值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns>MD5值</returns>
        public static string GetMD5(string sourceString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            return GetHash(sourceString, md5);
        }

        /// <summary>
        /// 获取SHA1值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns>SHA1值</returns>
        public static string GetSHA1(string sourceString)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            return GetHash(sourceString, sha1);
        }

        /// <summary>
        /// 获取SHA256值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns>SHA256值</returns>
        public static string GetSHA256(string sourceString)
        {
            SHA256 sha256 = SHA256.Create();
            return GetHash(sourceString, sha256);
        }

        /// <summary>
        /// 获取SHA384值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns>SHA384值</returns>
        public static string GetSHA384(string sourceString)
        {
            SHA384 sha384 = SHA384.Create();
            return GetHash(sourceString, sha384);
        }

        /// <summary>
        /// 获取SHA512值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns>SHA512值</returns>
        public static string GetSHA512(string sourceString)
        {
            SHA512 sha512 = SHA512.Create();
            return GetHash(sourceString, sha512);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileBase64String(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    try
                    {
                        return GetBase64String(reader.ReadBytes((int)fs.Length));
                    }
                    catch (System.Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string GetBase64String(string sourceString)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(sourceString);
            return GetBase64String(buffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceString"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetBase64String(string sourceString, Encoding encoding)
        {
            byte[] buffer = encoding.GetBytes(sourceString);
            return GetBase64String(buffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceBytes"></param>
        /// <returns></returns>
        public static string GetBase64String(byte[] sourceBytes)
        {
            string base64String = System.Convert.ToBase64String(sourceBytes);
            return base64String;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encode(string data)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes("Bbhc2018");
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes("Bbhc2018");

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);

        }

    }
    /// <summary>
    /// 
    /// </summary>
    public class DecryptHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decode(string data)
        {
            byte[] byKey = ASCIIEncoding.ASCII.GetBytes("Bbhc2018");
            byte[] byIV = ASCIIEncoding.ASCII.GetBytes("Bbhc2018");

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }
    }
}