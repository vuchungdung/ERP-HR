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

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public int Gender { get; set; }

        public string Image { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Degree { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string University { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Major { get; set; }

        public DateTime ApplyDate { get; set; }

        public int Experience { get; set; }

        public string FaceBook { get; set; }

        public string Zalo { get; set; }

        public string Skype { get; set; }

        public string LinkIn { get; set; }

        public int Rating { get; set; }

        [Required]
        public int ProviderId { get; set; }

        public string FileId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string SkillId { get; set; }

        public int JobId { get; set; }

        public int TagId { get; set; }
    }
}
