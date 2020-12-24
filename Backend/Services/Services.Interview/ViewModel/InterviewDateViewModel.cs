using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interview.ViewModel
{
    public class InterviewDateViewModel
    {
        public int DateId { get; set; }

        public int CandidateId { get; set; }

        public DateTime TimeDate { get; set; }

        public string Address { get; set; }

        public RecruitType RecruitType { get; set; }

        public int Time { get; set; }

        public int JodId { get; set; }

        public string Note { get; set; }

        public bool SendMail { get; set; }

        public string Email { get; set; }

        public int EmployeeId { get; set; }

        public string Employeename { get; set; }
    }
    public class ListDate
    {
        public string Title { get; set; }

        public int DateId { get; set; }

        public DateTime Date { get; set; }
    }
}
