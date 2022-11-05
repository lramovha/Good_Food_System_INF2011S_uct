using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GoodFoodSystem.BusinessLayer;

namespace GoodFoodSystem.PresentationLayer
{
    public partial class EmployeeListingForm : Form
    {
        #region Variables
        public bool listFormClosed;
        Collection<Employee> employees;
        public Role.RoleType roleValue;
        private EmployeeController employeeController;
        #endregion

        #region Property Method       
        public Role.RoleType RoleValue
        {
            set
            {
                roleValue = value;
            }

        }
        #endregion

        #region Constructor
        public EmployeeListingForm(EmployeeController empController)
        {
            InitializeComponent();
            employeeController = empController;
        }
        #endregion

        private void EmployeeListingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //listFormClosed to true
            listFormClosed = true;
        }
    }
}
