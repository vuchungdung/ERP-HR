using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public class JobDescriptionViewModel
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Endow { get; set; }
        public string SkillId { get; set; }
        public int OfferFrom { get; set; }
        public int OfferTo { get; set; }
        public string RequestJob { get; set; }
        public JobStatus Status { get; set; }
        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public DateTime CreateDate { get; set; }
        public int CategoryId { get; set; }
        public Core.CommonModel.Enum.Type Type { get; set; }
    }
}