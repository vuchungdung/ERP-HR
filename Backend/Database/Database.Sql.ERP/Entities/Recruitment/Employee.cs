using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Recruitment
{
    [Table("Employees")]
    public class Employee : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Address { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string Phone { get; set; }

        [Column(TypeName="datetime")]
        public DateTime? Dob { get; set; }

        public int? Gender { get; set; }
        public string Position { get; set; }
    }
}
