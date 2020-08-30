using Core.CommonModel;
using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Recruitment
{
    [Table("RecruitmentPlans")]
    public class RecruitmentPlan : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlanId { get; set; }

        [Required]
        public int JobId { get; set; }

        [Required]
        public int Quatity { get; set; }

        [Required]
        public PlanStatus Status { get; set; }
        public string Note { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        [Required]
        public DateTime TimeEnd { get; set; }
    }
}
