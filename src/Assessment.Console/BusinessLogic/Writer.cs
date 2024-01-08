using Assessment.Console.Models;
using Assessment.Shared;
using Microsoft.Extensions.Options;

namespace Assessment.Console.BusinessLogic
{
    public class Writer : IWriter
    {
        private readonly FileReaderSettings _fileReaderSettings;
        public Writer(IOptions<FileReaderSettings> fileReaderSettings)
        {
            _fileReaderSettings = fileReaderSettings.Value;
        }

        public void WriteUsersToFile(List<User> completeUsers)
        {
            if (completeUsers.Count == 0)
            {
                WriteLine("No users found!");
                return;
            }

            File.WriteAllLines(Path.Combine(_fileReaderSettings.FilePath, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{_fileReaderSettings.FileExtension}"), completeUsers.Select(user => $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}"));
            WriteLine("Done!");
        }
    }
}
