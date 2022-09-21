using GoodFoodSystem.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace GoodFoodSystem.DatabaseLayer
{
    public class EmployeeDB : DB
    {
        #region
        private string table1 = "HeadWaiter";
        private string sqlLocal1 = "SELCT * FROM HeadWaiter";
        private string table2 = "Runner";
        private string sqlLocal2 = "SELCT * FROM Runner";
        private string table3 = "Waiter";
        private string sqlLocal3 = "SELCT * FROM Waiter";
        private Collection<Employee> employees;
        #endregion

        #region
        public Collection<Employee> AllEmployees
        {
            get { return employees; }
            set { employees = value; }
        }
        #endregion

        #region
        public EmployeeDB()
        {
            Collection<Employee> empl = new Collection<Employee>();
            DB db = new DB();
            db.FillDataSet(sqlLocal1, table1);
            db.FillDataSet(sqlLocal2, table2);
            db.FillDataSet(sqlLocal3, table3);
        }
        #endregion
    }
}
