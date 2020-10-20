using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Common
{
    [Table("Tags")]
    public class Tag : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(200)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Content { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Color { get; set; }
    }
}
