using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Helper
{
    public interface IDatabaseHelper
    {
        void OpenConnection();

        void CloseConnection();

        DataTable ExecuteSProcedure(string nameProc, params object[] paramObjects);
    }
}
