using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Cadidate
{
    [Table("CadidateUsers")]
    public class CadidateUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(80)")]
        public string UserName { get; set; }
        [Required]
        [Column(TypeName ="varchar(120)")]
        public string Password { get; set; }
        public string CadidateId { get; set; }
    }
}
