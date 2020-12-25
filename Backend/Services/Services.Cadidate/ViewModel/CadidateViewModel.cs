using Database.Sql.ERP.Entities.Common;
using Microsoft.AspNetCore.Http;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Candidates.ViewModel
{
    public class CandidateViewModel
    {
        public int CandidateId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime? Dob { get; set; }

        public int? Gender { get; set; }

        public string Provider { get; set; }

        public string Img { get; set; }

        public string JobName { get; set; }

        public string ProcessName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string FilePath { get; set; }

        public string PdfName { get; set; }

        public string Facebook { get; set; }

        public string Zalo { get; set; }

        public string Skype { get; set; }

        public string LinkedIn { get; set; }
       

    }
    public class ListCandidateViewModel
    {
        public int CandidateId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime? Dob { get; set; }

        public int? Gender { get; set; }        

        public string Provider { get; set; }

        public string Category { get; set; }

        public string Img { get; set; }

        public string JobName { get; set; }

        public string ProcessName { get; set; }
        public DateTime CreatedDate { get; set; }

        public string FilePath { get; set; }

        public string PdfName { get; set; }

        public int JobId { get; set; }
    }
}
