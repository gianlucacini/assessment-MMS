using Assessment.Console.Models;
using Assessment.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using static System.Console;

namespace Assessment.Console.BusinessLogic
{
    public class Retriever : IRetriever
    {
        private readonly IUserApiClient _client;
        public Retriever(IUserApiClient client)
        {
            _client = client;
        }

        public async IAsyncEnumerable<User> GetCompleteUsers(IEnumerable<ICsv> users)
        {
            foreach (var user in users)
            {
                User completeUser = await _client.GetCompleteUser(user);

                if (completeUser is not null) yield return completeUser;
            }
        }
    }
}
