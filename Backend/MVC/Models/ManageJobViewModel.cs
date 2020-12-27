using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class ManageJobViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime ApplyDate { get; set; }
        public string p_Name { get; set; }
        public int JobId { get; set; }
        public int? Result { get; set; }
    }
}
