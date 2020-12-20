using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class WorkHistoryViewModel
    {
        public int Id { get; set; }

        public int CandidateId { get; set; }

        public string Position { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }
        public int? CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UpdateBy { get; set; }
        public bool Deleted { get; set; }
    }
}
