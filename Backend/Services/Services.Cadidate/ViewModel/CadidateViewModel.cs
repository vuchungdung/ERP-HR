using Database.Sql.ERP.Entities.Common;
using Microsoft.AspNetCore.Http;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Cadidates.ViewModel
{
    public class CadidateViewModel
    {
        public int CadidateId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime Dob { get; set; }

        public int Gender { get; set; }

        public string Degree { get; set; }

        public string University { get; set; }

        public string Major { get; set; }

        public DateTime ApplyDate { get; set; }

        public string Experience { get; set; }

        public string FaceBook { get; set; }

        public string Zalo { get; set; }

        public string Skype { get; set; }

        public string LinkIn { get; set; }

        public int Rating { get; set; }

        public int ProviderId { get; set; }

        public int CategoryId { get; set; }

        public string Skill { get; set; }

        public int JobId { get; set; }

        public int TagId { get; set; }

        public List<IFormFile> Files { get; set; }

    }
    public class ListCadidateViewModel
    {
        public int CadidateId { get; set; }

        public string Img { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime Dob { get; set; }

        public int Gender { get; set; }

        public string Degree { get; set; }

        public string University { get; set; }

        public string Major { get; set; }

        public DateTime ApplyDate { get; set; }

        public string Experience { get; set; }

        public string FaceBook { get; set; }

        public string Zalo { get; set; }

        public string Skype { get; set; }

        public string LinkIn { get; set; }

        public int Rating { get; set; }

        public string Provider { get; set; }

        public string Category { get; set; }

        public List<Skill> Skill { get; set; }

        public string Job { get; set; }

        public string Tag { get; set; }

    }
}
