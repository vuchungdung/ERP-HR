using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class CandidateViewModel
    {
        public int CandidateId { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime? Dob { get; set; }

        public int? Gender { get; set; }

        public List<AwardsViewModel> Awards { get; set; }
        public List<EducationViewModel> Educations { get; set; }
        public List<WorkHistoryViewModel> WorkHistories { get; set; }

        public string Skype { get; set; }

        public int JobId { get;set; }
        public string Zalo { get; set; }
        public string LinkId { get; set; }
        public string Facebook { get; set; }
        public string FilePath { get; set; }
        public string FileName{ get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
