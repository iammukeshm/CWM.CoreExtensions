using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CWM.CoreExtensions
{
    public static class DatatableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Object of Type T</typeparam>
        /// <param name="dataTable">Datatable</param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable dataTable)
        {

            var columnNames = dataTable.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .ToList();
            var properties = typeof(T).GetProperties();
            return dataTable.AsEnumerable().Select(row =>
            {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name))
                    {
                        PropertyInfo pI = objT.GetType().GetProperty(pro.Name);
                        pro.SetValue(objT, row[pro.Name] == DBNull.Value ? null : Convert.ChangeType(row[pro.Name], pI.PropertyType));
                    }
                }
                return objT;
            }).ToList();


        }
    }
}
