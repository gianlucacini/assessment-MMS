using Assessment.Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Console.BusinessLogic
{
    public class Reader
    {
        private readonly string _path;
        private readonly string _extension;
        private readonly string _separator;

        public Reader(string path, string extension, string separator)
        {
            _path = path;
            _extension = extension;
            _separator = separator;
        }
        public IEnumerable<Csv> GetUsersFromCsv()
        {
            var lines = File.ReadAllLines(Path.Combine(_path, $"input{_extension}"));

            IEnumerable<Csv> users = lines
               .Where(line => !string.IsNullOrEmpty(line))
               .Select(line =>
               {
                   var split = line.Split(_separator);

                   return new Csv
                   {
                       GivenName = split[0].Trim(),
                       FamilyName = split[1].Trim()
                   };
               });

            return users;
        }
    }
}
