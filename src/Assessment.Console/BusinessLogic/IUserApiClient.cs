using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.BusinessLogic
{
    public interface IUserApiClient
    {
        User GetCompleteUser(ICsv user);
    }
}