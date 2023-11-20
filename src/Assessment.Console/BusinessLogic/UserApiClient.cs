using Assessment.Console.Models;
using Assessment.Shared;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Assessment.Console.BusinessLogic
{
    public class UserApiClient
    {
        IHttpRequestFactory _httpRequestFactory;
        public UserApiClient(string origin)
        {
            _httpRequestFactory = new HttpRequestFactory(origin);
        }
        public User GetCompleteUser(ICsv user)
        {
            var builder = BuildRequestUri(user);

            var response = _httpRequestFactory.SendRequestMessage(builder);

            if (!response.IsSuccessStatusCode)
            {
                WriteLine("An error occured: {0}", response.ReasonPhrase);
                return null;
            }

            using var stream = response.Content.ReadAsStream();
            return JsonSerializer.Deserialize<User>(stream);
        }

        private NameValueCollection BuildRequestUri(ICsv user)
        {
            var builder = HttpUtility.ParseQueryString(string.Empty);

            builder.Add("given-name", user.GivenName);
            builder.Add("family-name", user.FamilyName);

            return builder;
        }
    }
}
