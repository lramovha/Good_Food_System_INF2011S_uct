using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFoodSystem.BusinessLayer
{
    public class Employee:Person
    {
        #region Info
        /*Create the derived class Employee from the Person class. 
          An employee has an employee number/ID and a role at the restaurant. 
          Since there are different types of employees with different ROLES in a restaurant, 
          we will create a Role class. Three derived classes (headwaiter, waiter and runner) 
          that inherit the role class will be created first 
          (We can say that a waiter IS A specific role an employee might have in the restaurant, etc.).
          The headwaiter has only salary as a data member. The runner and the waiter have the following attributes: 
          tips, rate and noOfShifts. For now do not include the constructor for these classes. 
          Implement the classes, observing OOP principles. Include encapsulation principles.   */
        #endregion

        #region Data Members
        //encapsulation
        private string empId;
        private Role role;
        #endregion

        #region Property methods
        public string EmployeeID
        {
            get { return empId; }
            set { empId = value; }
        }
        #endregion

        #region Constructor
        public Employee(Role roleValue)
        {
            switch (roleValue.getRoleValue) 
            {
                case Role.RoleType.Headwaiter:
                    role = new Headwaiter();
                    break;
                case Role.RoleType.Waiter:
                    role = new Waiter();
                    break;
                case Role.RoleType.Runner:
                    role = new Runner();
                    break;
                default:
                    role = new Role();
                    break;
            }
        }
        #endregion
    }
}