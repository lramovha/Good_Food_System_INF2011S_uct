using System;
using System.Collections.Generic;
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
    public partial class EmployeesMDIParent : Form
    {
        #region Variable
        private int childFormNumber = 0;
        Form employeeForm;
        Form employeeListForm;
        EmployeeController employeeController = new EmployeeController();
        #endregion

        #region Constructor
        public EmployeesMDIParent()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        #endregion

        #region Form generation
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        #endregion

        #region ToolstripMenus region

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        #endregion


        #region Employee ToolStrip Menus for Listing 
        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listHeadwaitersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeListForm == null)
            {
                //4.1 write the code to call the CreateNewEmployeeListForm method
                EmployeesMDIParent employeesMDIParent = new EmployeesMDIParent();
                employeesMDIParent.CreateNewEmployeeListForm();
            }
            //4.2 write the code to check if the employeeListForm is closed.
            //If it is, then call the CreateNewEmployeeListForm method
            if (employeeListForm == null)
            {
                CreateNewEmployeeListForm();
            }

            EmployeeListingForm empl;
            // employeeListForm.RoleValue = Role.RoleType.NoRole;
            //4.3 write the code to call the setUpEmployeeListView method
            // empl.setUpEmployeeListView();
            //4.4 write the code to show the employeeListForm form
        }

        private void listAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeListForm == null)
            {
                //4.1 write the code to call the CreateNewEmployeeListForm method
                EmployeesMDIParent employeesMDIParent = new EmployeesMDIParent();
                employeesMDIParent.CreateNewEmployeeListForm();
            }
            //4.2 write the code to check if the employeeListForm is closed.
            //If it is, then call the CreateNewEmployeeListForm method
            if (employeeListForm == null) 
            {
                CreateNewEmployeeListForm();
            }

            EmployeeListingForm empl;
           // employeeListForm.RoleValue = Role.RoleType.NoRole;
            //4.3 write the code to call the setUpEmployeeListView method
           // empl.setUpEmployeeListView();
            //4.4 write the code to show the employeeListForm form
        }

        private void listRunnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeListForm == null)
            {
                //4.1 write the code to call the CreateNewEmployeeListForm method
                EmployeesMDIParent employeesMDIParent = new EmployeesMDIParent();
                employeesMDIParent.CreateNewEmployeeListForm();
            }
            //4.2 write the code to check if the employeeListForm is closed.
            //If it is, then call the CreateNewEmployeeListForm method
            if (employeeListForm == null)
            {
                CreateNewEmployeeListForm();
            }

            EmployeeListingForm empl;
            // employeeListForm.RoleValue = Role.RoleType.NoRole;
            //4.3 write the code to call the setUpEmployeeListView method
            // empl.setUpEmployeeListView();
            //4.4 write the code to show the employeeListForm form
        }

        private void listWaitersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeListForm == null)
            {
                //4.1 write the code to call the CreateNewEmployeeListForm method
                EmployeesMDIParent employeesMDIParent = new EmployeesMDIParent();
                employeesMDIParent.CreateNewEmployeeListForm();
            }
            //4.2 write the code to check if the employeeListForm is closed.
            //If it is, then call the CreateNewEmployeeListForm method
            if (employeeListForm == null)
            {
                CreateNewEmployeeListForm();
            }

            EmployeeListingForm empl;
            // employeeListForm.RoleValue = Role.RoleType.NoRole;
            //4.3 write the code to call the setUpEmployeeListView method
            // empl.setUpEmployeeListView();
            //4.4 write the code to show the employeeListForm form
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Create a New ChildForm

        private void CreateNewEmployeeForm() 
        {
            employeeForm = new Form();
            employeeForm.MdiParent = this;
            employeeListForm.StartPosition = FormStartPosition.CenterScreen;
        }
        private void CreateNewEmployeeListForm()
        {
            employeeListForm = new Form();
            employeeListForm.MdiParent = this;
            employeeListForm.StartPosition = FormStartPosition.CenterScreen;
        }
        #endregion

        private void toolsMenu_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
