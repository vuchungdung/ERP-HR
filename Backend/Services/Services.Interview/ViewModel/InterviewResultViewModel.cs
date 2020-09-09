using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interview.ViewModel
{
    public class InterviewResultViewModel
    {
        public string Name { get; set; }

        public DateType DateType { get; set; }

        public string Note { get; set; }

        public Result Result { get; set; }
    }
}
