﻿using Assessment.Console.Models;
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
    public class UserApiClient : IUserApiClient
    {
        private readonly HttpClient _httpClient;
        public UserApiClient(HttpClient httpClient) => _httpClient = httpClient;
        public User GetCompleteUser(ICsv user)
        {
            var builder = BuildRequestUri(user);

            var request = new HttpRequestMessage(HttpMethod.Get, $"users?{builder}");

            var response = _httpClient.Send(request);

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
