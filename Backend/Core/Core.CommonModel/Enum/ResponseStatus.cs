using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CommonModel.Enum
{
    public enum ResponseStatus
    {
        Success = 1,
        Warning = 0,
        Error = -1,
        CodeExists = -2,
        GetDropDownError = -3,
        OutOfDateData = -4,
    }
}
