using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database.Sql.ERP.Entities.Interview
{
    public class InterviewProcess
    {
        [Key]
        [Column(Order =1)]
        public int CadidateId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProcessId { get; set; }
    }
}
