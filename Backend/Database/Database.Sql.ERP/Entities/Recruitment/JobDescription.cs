using Core.CommonModel;
using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Recruitment
{
    [Table("JobDescriptions")]
    public class JobDescription : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        public int PlanId { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Endow { get; set; } //quyền lợi

        [Required]
        public string SkillId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int OfferFrom { get; set; }

        [Required]
        public int OfferTo { get; set; }

        public JobStatus Status { get; set; }
    }
}
