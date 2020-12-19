using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class FileViewModel
    {
        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string FileType { get; set; }

        public int FileSize { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public int CandidateId { get; set; }
    }
}
