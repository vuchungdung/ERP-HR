using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.System.System
{
    [Table("UserRoles")]
    public class UserRole : BaseEntity
    {
        [Key]
        [Column(Order =1)]
        public int RoleId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int UserId { get; set; }
    }
}
