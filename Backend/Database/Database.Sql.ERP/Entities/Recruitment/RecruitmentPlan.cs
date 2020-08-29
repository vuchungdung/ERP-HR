using Core.CommonModel;
using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.Entities.Recruitment
{
    public class RecruitmentPlan : BaseEntity
    {
        public int PlanId { get; set; }
        public int JobId { get; set; }
        public int Quatity { get; set; }
        public PlanStatus Status { get; set; }
        public string Note { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}
