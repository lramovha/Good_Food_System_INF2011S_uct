using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFoodSystem.BusinessLayer
{
    public class Headwaiter : Role
    {
        #region Data Members
        //encapsulation
        protected decimal salary;
        #endregion


        #region Property methods
        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }
        #endregion

        #region Constructor
        public Headwaiter()
        {
            base.roleVal = RoleType.Headwaiter;
            base.description = "Headwaiter";
            salary = 0;
        }
        #endregion


        #region Methods

        public override decimal Payment()
        {
            return salary;
        }

        #endregion


    }
}
