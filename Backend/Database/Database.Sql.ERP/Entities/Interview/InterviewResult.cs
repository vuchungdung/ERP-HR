using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Sql.ERP.Entities.Interview
{
    public class InterviewResult
    {
        public int ResultId { get; set; }
        public int CadidateId { get; set; }
        public DateType DateType { get; set; }
        public string Note { get; set; }
        public int Result { get; set; }

    }
}
