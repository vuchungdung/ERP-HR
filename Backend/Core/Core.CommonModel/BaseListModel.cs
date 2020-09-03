using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel
{
    public class BaseListModel<T>
        where T : class
    {
        public IList<T> Items { get; set; }
        public int TotalItems { get; set; }
    }
}
