using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Recruitment.ViewModel
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public DateTime? Dob { get; set; }

        public int? Gender { get; set; }
        public string Position { get; set; }
    }
}
