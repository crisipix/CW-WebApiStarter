using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$.Common
{
    public interface IHttpClientProvider
    {
        HttpClient ProvideClient(string baseUrl, bool useWindowsAuth);
    }
}
