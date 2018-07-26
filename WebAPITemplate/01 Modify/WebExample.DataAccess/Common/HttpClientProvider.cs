using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Common
{
    public class HttpClientProvider : IHttpClientProvider
    {
        public HttpClient ProvideClient(string url, bool useWindowsAuth)
        {
            HttpClient client = null;

            if (useWindowsAuth)
            {
                var handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;
                client = new HttpClient(handler);
            }
            else {
                client = new HttpClient();
            }

            if (!string.IsNullOrEmpty(url)) {
                client.BaseAddress = new Uri(url);
            }

            return client;
        }
    }
}
