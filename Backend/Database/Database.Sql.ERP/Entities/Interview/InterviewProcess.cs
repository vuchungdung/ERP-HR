using Core.CommonModel;
using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Interview
{
    [Table("InterviewProcesses")]
    public class InterviewProcess : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int ProcessId { get; set; }
        public Result Result { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime ResultDate { get; set; }
    }
}
