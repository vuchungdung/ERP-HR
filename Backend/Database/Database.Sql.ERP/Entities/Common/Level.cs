using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Common
{
    [Table("Levels")]
    public class Level : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelId { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
