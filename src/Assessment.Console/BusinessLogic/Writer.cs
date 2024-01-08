using Assessment.Console.Models;
using Assessment.Shared;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace Assessment.Console.BusinessLogic
{
    public class Writer : IWriter
    {
        private readonly FileReaderSettings _fileReaderSettings;
        private readonly string filePath;
        public Writer(IOptions<FileReaderSettings> fileReaderSettings)
        {
            _fileReaderSettings = fileReaderSettings.Value;
            filePath = Path.Combine(_fileReaderSettings.FilePath, $"output_{DateTime.Now:yyyy-MM-dd hh-mm-ss}{_fileReaderSettings.FileExtension}");
        }

        public void WriteUsersToFile(List<User> completeUsers)
        {
            if (completeUsers.Count == 0)
            {
                WriteLine("No users found!");
                return;
            }
            completeUsers.ForEach(user =>
            {
                WriteUserToFile(user);
            });

            WriteLine("Done!");
        }

        public void WriteUserToFile(User user)
        {
            File.AppendAllText(filePath, $"Ciao {user.GivenName} {user.FamilyName} this is your email: {user.Email}" + Environment.NewLine);
        }
    }
}
