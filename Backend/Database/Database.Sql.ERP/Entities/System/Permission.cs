using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.System.System
{
    public class Permission
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)",Order = 1)]
        public string FunctionId { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)",Order = 2)]
        public string RoleId { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)",Order = 3)]
        public string CommandId { get; set; }
    }
}
