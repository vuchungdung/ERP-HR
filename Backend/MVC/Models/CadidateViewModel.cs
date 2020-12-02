using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class CadidateViewModel
    {
        public int CadidateId { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime? Dob { get; set; }

        public int? Gender { get; set; }

        public string Degree { get; set; }

        public string University { get; set; }

        public string Major { get; set; }

        public string Experience { get; set; }

        public string Skype { get; set; }

        public int JobId { get;set; }

        public List<IFormFile> Files { get; set; }
    }
}
