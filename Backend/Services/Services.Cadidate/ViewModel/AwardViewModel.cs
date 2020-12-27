using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Cadidates.ViewModel
{
    public class AwardViewModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public string Description { get; set; }

        public DateTime _From { get; set; }
        public DateTime _To { get; set; }
    }
}
