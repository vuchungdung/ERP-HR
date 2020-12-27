using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interview.ViewModel
{
    public class InterviewProcessViewModel
    {
        public int Id { get; set; }
        public int ApplyId { get; set; }
        public string Processname { get; set; }
        public int ProcessId { get; set; }
        public Result Result { get; set; }
    }
}
