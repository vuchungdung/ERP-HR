using Core.CommonModel;
using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Interview
{
    [Table("InterviewResults")]
    public class InterviewResult : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get; set; }
        
        public int DateId { get; set; }

        public string Note { get; set; }

        [Required]
        public Result Result { get; set; }

    }
}
