using Database.Sql.ERP.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.System
{
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
        [Column(TypeName = "nvarchar(200)")]
        public string BeginApply { get; set; }

        [Required]
        public int ProviderId { get; set; }

        [Required]
        public int TagId { get; set; }

        [Required]
        public DateTime Dob { get; set; }

        [Required]
        public int Gender { get; set; }

        [Required]
        public int JobId { get; set; }

        public string Image { get; set; }
    }
}
