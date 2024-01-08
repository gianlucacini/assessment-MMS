using Assessment.Console.Models;
using Assessment.Shared;

namespace Assessment.Console.BusinessLogic
{
    public interface IRetriever
    {
        Task<List<User>> GetCompleteUsers(IEnumerable<ICsv> users);
    }
}