using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Awards
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public string Description { get; set; }
        public int _From { get; set; }
        public int _To { get; set; }
    }
}
