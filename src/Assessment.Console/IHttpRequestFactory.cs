using System.Collections.Specialized;

namespace Assessment.Console
{
    public interface IHttpRequestFactory
    {
        HttpResponseMessage SendRequestMessage(NameValueCollection builder);
    }
}