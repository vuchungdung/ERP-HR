using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.System
{
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string UserName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Password { get; set; }

        public string Image { get; set; }
    }
}
