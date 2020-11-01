using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel
{
    [Serializable]
    public class UserSession
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
