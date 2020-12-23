using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Candidates.ViewModel
{
    public class WorkHistoryViewModel
    {
        public int Id { get; set; }

        public int CandidateId { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public string Position { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }
    }
}
