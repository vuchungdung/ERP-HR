using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Cadidate
{
    [Table("Cadidates")]
    public class Cadidate : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CadidateId { get; set; }

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

        [Column(TypeName = "nvarchar(20)")]
        public string Degree { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string University { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Major { get; set; }

        public DateTime? ApplyDate { get; set; }

        public string Experience { get; set; }

        public string FaceBook { get; set; }

        public string Zalo { get; set; }

        public string Skype { get; set; }

        public string LinkIn { get; set; }

        public int? Rating { get; set; }

        public int? ProviderId { get; set; }

        public int? CategoryId { get; set; }

        public string Skill { get; set; }

        public int? JobId { get; set; }

        public int? TagId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
