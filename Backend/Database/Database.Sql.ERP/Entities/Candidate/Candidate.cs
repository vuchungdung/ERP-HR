using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Candidate
{
    [Table("Candidates")]
    public class Candidate : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }

        public DateTime? Dob { get; set; }

        public int? Gender { get; set; }

        public DateTime? ApplyDate { get; set; }

        public string FaceBook { get; set; }

        public string Zalo { get; set; }

        public string Skype { get; set; }

        public string LinkIn { get; set; }

        public int? ProviderId { get; set; }

        public int? CategoryId { get; set; }

        public string Skill { get; set; }

        public int? JobId { get; set; }

        public int? TagId { get; set; }

        public int? InterviewId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int? ProcessId { get; set; }
    }
}
