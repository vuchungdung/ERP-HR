using System.Data;

namespace MVC.Helper
{
    public interface IDatabaseHelper
    {
        void OpenConnection();

        void CloseConnection();

        DataTable ExecuteSProcedure(string nameProc, params object[] paramObjects);
    }
}