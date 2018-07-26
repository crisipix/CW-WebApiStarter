using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Common
{
    public static class HttpClientExtensions
    {
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static async Task<string> GetJsonAsync(this HttpClient client, string url)
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            response.EnsureSuccessStatusCode();
            return string.Empty;
        }

        public static async Task<JObject> GetJObjectAsync(this HttpClient client, string url)
        {
            var jsonString = await client.GetJsonAsync(url);
            return JObject.Parse(jsonString);
        }

        public static async Task<JArray> GetJArrayAsync(this HttpClient client, string url)
        {
            var jsonString = await client.GetJsonAsync(url);
            return JArray.Parse(jsonString);
        }

        public static async Task<T> GetGenericAsync<T>(this HttpClient client, string url)
        {
            var jsonString = await client.GetJsonAsync(url);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static async Task<string> PostJsonAsync<T>(this HttpClient client, string url, T postObject) {
            var content = new StringContent(JObject.FromObject(postObject).ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            response.EnsureSuccessStatusCode();
            return string.Empty;
        }

        public static async Task<T> PostGenericAsync<T>(this HttpClient client, string url, T postObject)
        {
            var jsonString = await PostJsonAsync(client, url, postObject);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        public static async Task<TResult> PostGenericAsync<T,TResult>(this HttpClient client, string url, T postObject)
        {
            var jsonString = await PostJsonAsync(client, url, postObject);
            return JsonConvert.DeserializeObject<TResult>(jsonString);
        }

        public static async Task<string> PutJsonAsync<T>(this HttpClient client, string url, T postObject)
        {
            var content = new StringContent(JObject.FromObject(postObject).ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return jsonString;
            }
            response.EnsureSuccessStatusCode();
            return string.Empty;
        }

        public static async Task<T> PutGenericAsync<T>(this HttpClient client, string url, T postObject)
        {
            var jsonString = await PutJsonAsync(client, url, postObject);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
        public static async Task<TResult> PutGenericAsync<T, TResult>(this HttpClient client, string url, T postObject)
        {
            var jsonString = await PutJsonAsync(client, url, postObject);
            return JsonConvert.DeserializeObject<TResult>(jsonString);
        }

        public static async Task<bool> DeleteJsonAsync(this HttpClient client, string url)
        {
            HttpResponseMessage response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return true;
            }
            response.EnsureSuccessStatusCode();
            return false;
        }


        //https://stackoverflow.com/questions/12519561/throw-httpresponseexception-or-return-request-createerrorresponse
        private static void HandleResponseException(Exception ex, string resourcePath) {
            _logger.Error($"Error Calling : {resourcePath}");
            if (ex is TaskCanceledException)
            {
                throw new ApplicationException($"Request Timed Out : {resourcePath}");
            }
            if (ex is HttpRequestException)
            {
                if (ex.InnerException != null && ex.InnerException is WebException  ) {
                    var we = ex.InnerException;
                    if (we.Message.StartsWith("Server")) {
                        throw new ApplicationException($"Request Server Down : {resourcePath}");
                    }
                    
                }
            }


        }
    }
}
