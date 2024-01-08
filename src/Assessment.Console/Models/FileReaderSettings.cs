using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Console.Models
{
    public sealed class FileReaderSettings
    {
        public string WordSeparator { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
    }
}
