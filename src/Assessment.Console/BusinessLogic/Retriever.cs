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
        private readonly string _origin;
        public Retriever(string origin)
        {
            _origin = origin;
        }

        public List<User> GetCompleteUsers(IEnumerable<ICsv> users)
        {
            UserApiClient userApiClient = new UserApiClient(_origin);

            var completeUsers = new List<User>();

            foreach (var user in users)
            {
                User completeUser = userApiClient.GetCompleteUser(user);

                if (completeUser is null) continue;

                completeUsers.Add(completeUser);
            }

            return completeUsers;

        }
    }
}
