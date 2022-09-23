using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodFoodSystem.BusinessLayer;

namespace GoodFoodSystem.DatabaseLayer
{
    public class EmployeeDB:DB
    {
        #region  Data members 
        private string table1 = "HeadWaiter";
        private string sqlLocal1 = "SELECT * FROM HeadWaiter";
        private string table2 = "Waiter";
        private string sqlLocal2 = "SELECT * FROM Waiter";
        private string table3 = "Runner";
        private string sqlLocal3 = "SELECT * FROM Runner";
        private Collection<Employee> employees;
        #endregion

        #region Property Method: Collection
        public Collection<Employee> AllEmployees
        {
            get
            {
                return employees;
            }
        }
        #endregion
        
        #region Constructor
        public EmployeeDB() : base()
        {
            employees = new Collection<Employee>();
            FillDataSet(sqlLocal1, table1);
            Add2Collection(table1);
            FillDataSet(sqlLocal2, table2);
            Add2Collection(table2);
            FillDataSet(sqlLocal3, table3);
            Add2Collection(table3);

        }
        #endregion

        #region Utility Methods
        public DataSet GetDataSet()
        {
            return dsMain;
        }
        private void Add2Collection(string table)
        {
            //Declare references to a myRow object and an Employee object
            DataRow myRow = null;
            Employee anEmp;
            HeadWaiter headw;
            Waiter waiter;
            Runner runner;
            Role.RoleType roleValue = Role.RoleType.NoRole;  //Declare roleValue and initialise
            switch (table)
            {
                case "HeadWaiter":
                    roleValue = Role.RoleType.Headwaiter;
                    break;
                case "Waiter":
                    roleValue = Role.RoleType.Waiter;
                    break;
                case "Runner":
                    roleValue = Role.RoleType.Runner;
                    break;
            }
            //READ from the table  
            foreach (DataRow myRow_loopVariable in dsMain.Tables[table].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    //Instantiate a new Employee object
                    anEmp = new Employee(roleValue);
                    //Obtain each employee attribute from the specific field in the row in the table
                    anEmp.ID = Convert.ToString(myRow["ID"]).TrimEnd();
                    //Do the same for all other attributes
                    anEmp.EmployeeID = Convert.ToString(myRow["EmpID"]).TrimEnd();
                    anEmp.Name = Convert.ToString(myRow["Name"]).TrimEnd();
                    anEmp.Telephone = Convert.ToString(myRow["Phone"]).TrimEnd();
                    anEmp.role.getRoleValue = (Role.RoleType)Convert.ToByte(myRow["Role"]);
                    //Depending on Role read more Values
                    switch (anEmp.role.getRoleValue)
                    {
                        case Role.RoleType.Headwaiter:
                            headw = (HeadWaiter)anEmp.role;
                            headw.SalaryAmount = Convert.ToDecimal(myRow["Salary"]);
                            break;
                        case Role.RoleType.Waiter:
                            waiter = (Waiter)anEmp.role;
                            waiter.getRate = Convert.ToDecimal(myRow["DayRate"]);
                            waiter.getShifts = Convert.ToInt32(myRow["NoOfShifts"]);
                            break;
                        case Role.RoleType.Runner:
                            runner = (Runner)anEmp.role;
                            runner.getRate = Convert.ToDecimal(myRow["DayRate"]);
                            runner.getShifts = Convert.ToInt32(myRow["NoOfShifts"]);
                            break;
                    }
                    employees.Add(anEmp);
                }
            }
        }
        private void FillRow(DataRow aRow, Employee anEmp)
        {
            HeadWaiter headwaiter;
            Runner runner;
            Waiter waiter;
            aRow["ID"] = anEmp.ID;  //NOTE square brackets to indicate index of collections of fields in row.
            aRow["EmpID"] = anEmp.EmployeeID;
            aRow["Name"] = anEmp.Name;
            aRow["Phone"] = anEmp.Telephone;
            aRow["Role"] = (byte)anEmp.role.getRoleValue;
            //*** For each role add the specific data variables
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    headwaiter = (HeadWaiter)anEmp.role;
                    aRow["Salary"] = headwaiter.SalaryAmount;
                    break;
                case Role.RoleType.Waiter:
                    waiter = (Waiter)anEmp.role;
                    aRow["DayRate"] = waiter.getRate;
                    aRow["NoOfShifts"] = waiter.getShifts;
                    aRow["Tips"] = waiter.getTips;
                    break;
                case Role.RoleType.Runner:
                    runner = (Runner)anEmp.role;
                    aRow["DayRate"] = runner.getRate;
                    aRow["NoOfShifts"] = runner.getShifts;
                    break;
            }
        }
        #endregion

        #region Database Operations CRUD
        public void DataSetChange(Employee anEmp)
        {
            DataRow aRow = null;
            string dataTable = table1;
            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    dataTable = table1;
                    // aRow = dsMain.Tables[dataTable].NewRow();
                    // FillRow(aRow, anEmp);
                    // //Add to the dataset
                    //dsMain.Tables[dataTable].Rows.Add(aRow);
                    break;
                case Role.RoleType.Waiter:
                    dataTable = table2;
                    break;
                case Role.RoleType.Runner:
                    dataTable = table3;
                    break;
            }
            aRow = dsMain.Tables[dataTable].NewRow();
            FillRow(aRow, anEmp);
            //Add to the dataset
            dsMain.Tables[dataTable].Rows.Add(aRow);
        }
        #endregion

        #region Build Parameters

        public void Build_INSERT_Parameters(Employee anEmp)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@EMPID", SqlDbType.NVarChar, 10, " EMPID ");
            daMain.InsertCommand.Parameters.Add(param);

            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    param = new SqlParameter("@Salary", SqlDbType.Money, 8, "Salary");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Runner:
                    param = new SqlParameter("@Salary", SqlDbType.Money, 8, "Salary");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
                case Role.RoleType.Waiter:
                    param = new SqlParameter("@Salary", SqlDbType.Money, 8, "Salary");
                    daMain.InsertCommand.Parameters.Add(param);
                    break;
            }
        }
        public void Create_INSERT_Command(Employee anEmp)
        {
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.NVarChar, 15, "ID");
            daMain.InsertCommand.Parameters.Add(param);
            param = new SqlParameter("@EMPID", SqlDbType.NVarChar, 10, " EMPID ");
            daMain.InsertCommand.Parameters.Add(param);

            switch (anEmp.role.getRoleValue)
            {
                case Role.RoleType.Headwaiter:
                    daMain.InsertCommand = new SqlCommand("INSERT into HeadWaiter (ID, EMPID, Name,Phone, Role, Salary) VALUES(@ID, @EmpID, @Name, @Phone, @Role, @Salary)", cnMain);
                    break;
                case Role.RoleType.Runner:
                    daMain.InsertCommand = new SqlCommand("INSERT into Runner (ID, EMPID, Name, Phone, Role, Salary) VALUES(@ID, @EmpID, @Name, @Phone, @Role, @Salary)", cnMain);
                    break;
                case Role.RoleType.Waiter:
                    daMain.InsertCommand = new SqlCommand("INSERT into Waiter (ID, EMPID, Name, Phone, Role, Salary) VALUES(@ID, @EmpID, @Name, @Phone, @Role, @Salary)", cnMain);
                    break;
            }
            Build_INSERT_Parameters(anEmp);
        }

        public bool UpdateDataSource(Employee anEmp)
        {
            bool success = true;

            Create_INSERT_Command(anEmp);
            switch (anEmp.role.getRoleValue) 
            {
                case Role.RoleType.Headwaiter:
                    success = UpdateDataSource(anEmp);
                case Role.RoleType.Runner:
                    success = UpdateDataSource(anEmp);
                case Role.RoleType.Waiter:
                    success = UpdateDataSource(anEmp);
            }

        }
       
        #endregion

        #region Create Commands
        #endregion

        #region Update database
        #endregion

    }
}
