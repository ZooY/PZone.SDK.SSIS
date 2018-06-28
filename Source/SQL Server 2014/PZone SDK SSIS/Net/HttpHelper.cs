using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;


namespace SSIS.Net
{
    public class HttpHelper
    {
        /// <summary>
        /// Отправка запроса типа POST.
        /// </summary>
        /// <param name="url">Адрес отправки запроса.</param>
        /// <param name="data">Данные запроса в формате параметров URL (UrlEncoded).</param>
        /// <remarks>
        /// <para>В параметре <paramref name="data"/> данные должны быть закодированы с помощью метода <see cref="System.Web.HttpUtility.UrlEncode(string)" />.</para>
        /// </remarks>
        /// <returns>Метод возвращает ответ в виде строки.</returns>
        public static string Post(string url, string data)
        {
            return Post(url, "application/x-www-form-urlencoded", data);
        }


        /// <summary>
        /// Отправка запроса типа POST, возвращаеющего ответ в формете JSON.
        /// </summary>
        /// <param name="url">Адрес отправки запроса.</param>
        /// <param name="data">Данные запроса в формате параметров URL (UrlEncoded).</param>
        /// <returns>Метод возвращает ответ в виде объекта, десериализованного из ответа в формате JSON.</returns>
        public static T Post<T>(string url, string data)
        {
            var json = Post(url, data);
            return new JavaScriptSerializer().Deserialize<T>(json);
        }

        
        private static string Post(string url, string contentType, string data)
        {
            var postData = Encoding.UTF8.GetBytes(data);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.ServicePoint.ConnectionLimit = int.MaxValue;
            request.Method = "POST";
            request.ContentType = contentType;
            request.ContentLength = postData.Length;
            request.Timeout = int.MaxValue;
            //request.Proxy.Credentials = CredentialCache.DefaultNetworkCredentials;

            using (var dataStream = request.GetRequestStream())
            {
                dataStream.Write(postData, 0, postData.Length);
            }

            string response;
            using (var webResponse = request.GetResponse())
            {
                var responseStream = webResponse.GetResponseStream();
                if (responseStream == null)
                    throw new Exception("Сервис вернул пустой ответ.");
                using (var streamReader = new StreamReader(responseStream))
                {
                    response = streamReader.ReadToEnd();
                }
            }
            return response;
        }
    }
}