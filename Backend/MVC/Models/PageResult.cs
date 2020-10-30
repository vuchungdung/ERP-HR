using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class PageResult<T>
    {
        public List<T> ListItems { get; set; }
        public int TotalRecords { get; set; }
    }
}
