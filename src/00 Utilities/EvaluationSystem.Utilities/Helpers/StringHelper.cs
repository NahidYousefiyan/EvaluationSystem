using System;
using System.IO;
using System.Text;

namespace EvaluationSystem.Utilities.Helpers
{
    public class StringHelper
    {
        public static string GetBase64(string text)
        {
            try
            {
                return Convert.ToBase64String(StringToByteArray(text));
            }
            catch
            {
                return null;
            }
        }
        public static string GetBase64(byte[] Data)
        {
            try
            {
                return Convert.ToBase64String(Data);
            }
            catch
            {
                return null;
            }
        }
        public static byte[] Base64ToByteArray(string Base64)
        {
            try
            {
                return Convert.FromBase64String(Base64);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static string Base64ToString(string Base64)
        {
            try
            {
                byte[] keyBytes = Convert.FromBase64String(Base64);
                var stringKey = Encoding.UTF8.GetString(keyBytes);
                return stringKey;
            }
            catch
            {
                return null;
            }
        }

        public static string ByteArrayToString(byte[] Data)
        {
            try
            {
                return Encoding.UTF8.GetString(Data);
            }
            catch
            {
                return null;
            }
        }
        public static byte[] StringToByteArray(string txt)
        {
            try
            {
                return Encoding.UTF8.GetBytes(txt);
            }
            catch
            {
                return null;
            }
        }

        public static StreamReader StringToStreamReader(string txt)
        {
            var bytearray = StringToByteArray(txt);
            MemoryStream stream = new MemoryStream(bytearray);
            StreamReader reader = new StreamReader(stream);
            return reader;
        }

        public static T StreamToObject<T>(Stream stream) where T : class
        {
            try
            {
                using (var reader = new StreamReader(stream))
                {
                    var data = reader.ReadToEnd();
                    stream.Position = 0;
                    var model = SerializerHelper.DeSerialize<T>(data);
                    return model;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static T StringToObject<T>(string strvalue) where T : class
        {
            try
            {
                var model = SerializerHelper.DeSerialize<T>(strvalue);
                return model;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool HasValue(string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                return false;

            return true;
        }
    }
}
