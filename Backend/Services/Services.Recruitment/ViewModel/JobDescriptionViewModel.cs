using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Recruitment.ViewModel
{
    public class JobDescriptionViewModel
    {
        public int JobId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string RequestJob { get; set; }

        public string Endow { get; set; }

        public List<string> SkillNames { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string Benefit { get; set; }

        public int OfferFrom { get; set; }

        public int OfferTo { get; set; }

        public int Quatity { get; set; }

        public DateTime TimeEnd { get; set; }

        public DateTime TimeStart { get; set; }

        public string Skill { get; set; }

        public JobStatus Status { get; set; }

        public DateTime CreateDate { get; set; }

        public Core.CommonModel.Enum.Type Type { get; set; }
    }
}
