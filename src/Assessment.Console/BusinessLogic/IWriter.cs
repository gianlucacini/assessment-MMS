using Assessment.Shared;

namespace Assessment.Console.BusinessLogic
{
    public interface IWriter
    {
        void WriteUsersToFile(List<User> completeUsers);
    }
}