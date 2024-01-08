using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.BusinessLogic
{
    public interface IUserApiClient
    {
        Task<User> GetCompleteUser(ICsv user);
    }
}