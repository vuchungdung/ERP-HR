using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Common.ViewModel
{
    public class FileCvViewModel
    {
        public int CVId { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public string FileType { get; set; }

        public int FileSize { get; set; }

        public string Name { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
