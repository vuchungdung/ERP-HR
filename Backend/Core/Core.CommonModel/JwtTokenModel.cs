using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel
{
    public class JwtTokenModel
    {
        public string AccessToken { get; set; }
        public long Expiration { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
    }
}
