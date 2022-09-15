using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodFoodSystem.BusinessLayer
{
    internal class Waiter : Role
    {
        #region Data Members
        //encapsulation
        protected decimal tips;
        protected decimal rate;
        protected decimal noOfShifts;
        #endregion

        #region Property methods
        public decimal Tips
        {
            get { return tips; }
            set { tips = value; }
        }

        public decimal Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public decimal NoOfShifts
        {
            get { return noOfShifts; }
            set { noOfShifts = value; }
        }
        #endregion

        #region Constructor
        public Waiter()
        {
            tips = 0;
            rate = 0;
            noOfShifts = 0;
            roleVal = RoleType.Waiter;
            description = "Waiter";
        }
        #endregion


        #region Methods

        public override decimal Payment()
        {
            return rate * noOfShifts + tips;
        }
        #endregion
    }
}
