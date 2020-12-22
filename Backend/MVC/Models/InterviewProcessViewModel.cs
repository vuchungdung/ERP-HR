using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class InterviewProcessViewModel
    {
        public int CandidateId { get; set; }
        public int ProcessId { get; set; }
        public int CreateBy { get; set; }
        public int CreateDate { get; set; }
    }
}
