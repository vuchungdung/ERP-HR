using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel
{
    public class BaseViewModel
    {
        public string CreateBy { get; set; }

        public DateTime CreateDate { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool Deleted { get; set; } = false;

    }
}
