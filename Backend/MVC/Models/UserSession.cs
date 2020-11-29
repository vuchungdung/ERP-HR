using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    [Serializable]
    public class UserSession
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public string Image { get; set; }
    }
}
