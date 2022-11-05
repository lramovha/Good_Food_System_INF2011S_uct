using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodFoodSystem.DatabaseLayer;
using GoodFoodSystem.BusinessLayer;
using System.Windows.Forms;

namespace GoodFoodSystem.BusinessLayer
{
    public class EmployeeController
    {
        #region Data Members
        EmployeeDB employeeDB;
        Collection<Employee> employees;
        EmployeeController employeeController; //

        #endregion

        #region methods
        public Collection<Employee> AllEmployees
        {
            get { return employees; }
            set { employees = value; }
        }

        public Collection<Employee> FindByRole(Collection<Employee> emps, Role.RoleType roleVal)
        {
            Collection<Employee> matches = new Collection<Employee>();
            foreach (Employee emp in emps)
            {
                // 2.2.1 Write the code here to check if the role has been found (i.e if the employee (emp)
                // role matches the roleVal, then)
                if (emp.role.Equals(roleVal))
                {
                    //2.2.2 write the code to add the match to the collection, i.e add emp to matches –
                    // check your notices on how to add item to a collection
                    matches.Add(emp);
                }
            }
            // 2.2.3 write the code to return the collection
            return matches;
        }
            #endregion

            #region Constructor
            public EmployeeController()
        {
            //***instantiate the EmployeeDB object to communicate with the database
            employeeDB = new EmployeeDB();
            employees = employeeDB.AllEmployees;
        }
        #endregion

        #region Database Communication.
        public void DataMaintenance(Employee anEmp)
        {
            //perform a given database operation to the dataset in memory; 
            employeeDB.DataSetChange(anEmp);
            employees.Add(anEmp);
        }

        //***Commit the changes to the database
        public bool FinalizeChanges(Employee employee)
        {
            //***call the EmployeeDB method that will commit the changes to the database
            return employeeDB.UpdateDataSource(employee);

        }
        #endregion
    }
}
