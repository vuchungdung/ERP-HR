using Core.CommonModel.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            this.Errors = new List<string>();
        }
        public List<string> Errors { get; set; }
        public object Result { get; set; }
        public ResponseStatus Status { get; set; }
    }
}
