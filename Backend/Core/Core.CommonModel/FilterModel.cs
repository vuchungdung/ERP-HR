using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel
{
    public class FilterModel
    {
        public string Text { get; set; }
        public string CandidateId { get; set; }
        public PagingModel Paging { get; set; } = new PagingModel();
    }
}
