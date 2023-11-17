using Assessment.Shared;

namespace Assessment.Console.BusinessLogic
{
    public class Writer
    {
        private readonly string _path;
        private readonly string _extension;
        public Writer(string path, string extension)
        {
            _path = path;
            _extension = extension;
        }

        public void WriteUsersToFile(List<User> completeUsers)
        {
            if (completeUsers.Count == 0)
            {
                WriteLine("No users found!");
                return;
            }

            File.WriteAllLines(Path.Combine(_path, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{_extension}"), completeUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
            WriteLine("Done!");
        }
    }
}
