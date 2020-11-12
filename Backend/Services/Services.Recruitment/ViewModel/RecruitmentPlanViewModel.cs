using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Recruitment.ViewModel
{
    public class RecruitmentPlanViewModel
    {
        public int PlanId { get; set; }

        public string Title { get; set; }

        public string JobTitle { get; set; }

        public int Quatity { get; set; }

        public PlanStatus Status { get; set; }
        public string Note { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
