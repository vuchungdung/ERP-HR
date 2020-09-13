using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interview.ViewModel
{
    public class InterviewDateViewModel
    {
        public int DateId { get; set; }

        public int CadidateId { get; set; }

        public DateTime TimeDate { get; set; }

        public DateTime TimeStart { get; set; }

        public string Address { get; set; }

        public RecruitType RecruitType { get; set; }

        public int Time { get; set; }

        public int JodId { get; set; }

        public string Note { get; set; }

        public bool SendMail { get; set; }
    }
}
