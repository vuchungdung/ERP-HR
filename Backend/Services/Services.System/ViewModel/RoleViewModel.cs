using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.System.ViewModel
{
    public class RoleViewModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
