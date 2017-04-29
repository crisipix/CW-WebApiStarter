using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebExample.DataAccess.Common
{
    public static class HttpClientExtensions
    {
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
    }
}
