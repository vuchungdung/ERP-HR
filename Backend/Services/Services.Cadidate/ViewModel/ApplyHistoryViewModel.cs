using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Cadidates.ViewModel
{
    public class ApplyHistoryViewModel
    {
        public int Id { get; set; }

        public int CadidateId { get; set; }

        public DateTime TimeStart { get; set; }

        public DateTime TimeEnd { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }
    }
}
