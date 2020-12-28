using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel
{
    public class FilterModel
    {
        public string Text { get; set; }
        public string CandidateId { get; set; }
        public int ProcessId { get; set; } = 0;
        public int JobId { get; set; } = 0;
        public PagingModel Paging { get; set; } = new PagingModel();
    }
}
