using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class PageViewModel
    {
        public int PageIndex { get; set; }
        public int Pagesize { get; set; }
        public string Keyword { get; set; }
        public int? Categoryid { get; set; }
        public Core.CommonModel.Enum.Type? Type { get; set; }
    }
}
