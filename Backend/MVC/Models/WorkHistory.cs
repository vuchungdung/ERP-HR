using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class WorkHistory
    {
        public int Id { get; set; }

        public int CandidateId { get; set; }

        public string Position { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }
    }
}
