using Core.CommonModel;
using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Interview
{
    [Table("InterviewDates")]
    public class InterviewDate : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DateId { get; set; }

        [Required]
        public int CadidateId { get; set; }

        [Required]
        public DateTime TimeDate { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Address { get; set; }

        [Required]
        public RecruitType RecruitType { get; set; }

        [Required]
        public int Time { get; set; }

        [Required]
        public int JodId { get; set; }

        public string Note { get; set; }

        public bool SendMail { get; set; }
    }
}
