using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Console
{
    public class HttpRequestFactory : IHttpRequestFactory
    {
        HttpClient HttpClient; 
        public HttpRequestFactory(string origin)
        {
            this.HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(origin)
            };
        }
        public HttpResponseMessage SendRequestMessage(NameValueCollection builder)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"users?{builder}");

            return HttpClient.Send(request);

        }
    }
}
