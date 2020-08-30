using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Common
{
    [Table("Skills")]
    public class Skill : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }

        [Required]
        public int Name { get; set; }
    }
}
