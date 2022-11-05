using System.Windows.Forms;
using GoodFoodSystem.DatabaseLayer;
using GoodFoodSystem.BusinessLayer;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace GoodFoodSystem.PresentationLayer
{
    partial class EmployeeListingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listLabel = new System.Windows.Forms.Label();
            this.employeeListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listLabel
            // 
            this.listLabel.AutoSize = true;
            this.listLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listLabel.Location = new System.Drawing.Point(433, 40);
            this.listLabel.Name = "listLabel";
            this.listLabel.Size = new System.Drawing.Size(41, 20);
            this.listLabel.TabIndex = 0;
            this.listLabel.Text = "List";
            // 
            // employeeListView
            // 
            this.employeeListView.HideSelection = false;
            this.employeeListView.Location = new System.Drawing.Point(85, 85);
            this.employeeListView.Name = "employeeListView";
            this.employeeListView.Size = new System.Drawing.Size(882, 393);
            this.employeeListView.TabIndex = 1;
            this.employeeListView.UseCompatibleStateImageBehavior = false;
            // 
            // EmployeeListingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 494);
            this.Controls.Add(this.employeeListView);
            this.Controls.Add(this.listLabel);
            this.Name = "EmployeeListingForm";
            this.Text = "Employee Listing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EmployeeListingForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label listLabel;
        private System.Windows.Forms.ListView employeeListView;

        #region method
        public void setUpEmployeeListView()
        {
            ListViewItem employeeDetails;
            HeadWaiter headW;
            Waiter waiter;
            Runner runner;
            Collection<Employee> employees = null;
            employeeListView.Clear();
            employeeListView.Columns.Insert(0, "ID", 120, HorizontalAlignment.Left);
            employeeListView.Columns.Insert(1, "EMPID", 120, HorizontalAlignment.Left);
            employeeListView.Columns.Insert(2, "Name", 120, HorizontalAlignment.Left);
            employeeListView.Columns.Insert(3, "Phone", 120, HorizontalAlignment.Left);
            //employeeListView.Columns.Insert(4, "Role", 120, HorizontalAlignment.Left);
            //employeeListView.Columns.Insert(0, "Salary", 120, HorizontalAlignment.Left);

            switch (roleValue)
            {
                case Role.RoleType.NoRole:
                    employees = employeeController.AllEmployees; listLabel.Text = "Listing of all employees";
                    employeeListView.Columns.Insert(4, "Payment", 100, HorizontalAlignment.Center);
                    break;
                case Role.RoleType.Headwaiter:
                    //Add a FindByRole method to the EmployeeController
                    employees = employeeController.FindByRole(employeeController.AllEmployees,
                    Role.RoleType.Headwaiter);
                    listLabel.Text = "Listing of all Headwaiters";
                    //Set Up Columns of List View
                    employeeListView.Columns.Insert(4, "Salary", 100, HorizontalAlignment.Center);
                    break;
                //do for the other roles
                case Role.RoleType.Waiter:
                    //Add a FindByRole method to the EmployeeController
                    employees = employeeController.FindByRole(employeeController.AllEmployees,
                    Role.RoleType.Waiter);
                    listLabel.Text = "Listing of all Waiters";
                    //Set Up Columns of List View
                    employeeListView.Columns.Insert(4, "Salary", 100, HorizontalAlignment.Center);
                    break;
                case Role.RoleType.Runner:
                    //Add a FindByRole method to the EmployeeController
                    employees = employeeController.FindByRole(employeeController.AllEmployees,
                    Role.RoleType.Runner);
                    listLabel.Text = "Listing of all runners";
                    //Set Up Columns of List View
                    employeeListView.Columns.Insert(4, "Salary", 100, HorizontalAlignment.Center);
                    break;
            }

            foreach (Employee employee in employees)
            {
                employeeDetails = new ListViewItem();
                employeeDetails.Text = employee.ID.ToString();
                // Do the same for EmpID, Name and Phone
                switch (employee.role.getRoleValue)
                {
                    case Role.RoleType.Headwaiter:
                        headW = (HeadWaiter)employee.role;
                        employeeDetails.SubItems.Add(headW.SalaryAmount.ToString());
                        break;
                    //write the code to finish the other employee roles
                    case Role.RoleType.Waiter:
                        waiter = (Waiter)employee.role;
                        employeeDetails.SubItems.Add(waiter.SalaryAmount.ToString());
                        break;
                    case Role.RoleType.Runner:
                        runner = (Runner)employee.role;
                        employeeDetails.SubItems.Add(runner.SalaryAmount.ToString());
                        break;
                }
                employeeListView.Items.Add(employeeDetails);
            }
            employeeListView.Refresh();
            employeeListView.GridLines = true;
        }
        #endregion

    }
}