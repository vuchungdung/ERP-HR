using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Recruitment
{
    [Table("JobDescriptions")]
    public class JobDescription : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        [Required]
        [Column(TypeName ="nvarchar(100)")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string SkillId { get; set; }

        [Required]
        public int LevelId { get; set; }
    }
}
