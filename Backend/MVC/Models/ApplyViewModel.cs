using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class ApplyViewModel
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public int JobId { get; set; }
        public DateTime ApplyDate { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public IFormFile File { get; set; }
    }
}
