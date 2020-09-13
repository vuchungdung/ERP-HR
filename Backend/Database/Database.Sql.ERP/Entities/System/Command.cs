using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.System
{
    [Table("Commands")]
    public class Command : BaseEntity
    {
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [Key]
        public string CommandId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
