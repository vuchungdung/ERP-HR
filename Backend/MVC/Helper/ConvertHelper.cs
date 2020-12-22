using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace MVC.Helper
{
    public static class ConvertHelper
    {
        public static IList<T> ConvertTo<T>(this DataTable table)
        {
            List<T> data = new List<T>();

            if (table == null)
            {
                return null;
            }

            foreach (DataRow row in table.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T GetItem<T>(this DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                    {
                        if(dr[column.ColumnName] == DBNull.Value)
                        {
                            pro.SetValue(obj, null, null);
                        }
                        else
                        {
                            pro.SetValue(obj, dr[column.ColumnName], null);
                        }
                    }
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}