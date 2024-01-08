using Assessment.Console.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Console.BusinessLogic
{
    public class Reader : IReader
    {
        private readonly FileReaderSettings _fileReaderSettings;

        public Reader(IOptions<FileReaderSettings> fileReaderSettings)
        {
            _fileReaderSettings = fileReaderSettings.Value;
        }
        public IEnumerable<ICsv> GetUsersFromCsv()
        {
            var lines = File.ReadAllLines(Path.Combine(_fileReaderSettings.FilePath, $"input{_fileReaderSettings.FileExtension}"));

            IEnumerable<ICsv> users = lines
               .Where(line => !string.IsNullOrEmpty(line))
               .Select(line =>
               {
                   var split = line.Split(_fileReaderSettings.WordSeparator);

                   return new Csv(split[0].Trim(), split[1].Trim());
               });

            return users;
        }
    }
}
