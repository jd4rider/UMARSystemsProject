using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenStuff;

namespace UMARSystemsProject
{
    public partial class ARProdLog : Form
    {
        public string name = LoginForm.Globals.globalName;
        public string userName = LoginForm.Globals.globalUsername;

        public ARProdLog()
        {
            InitializeComponent();
            usernameLabel.Text = "Hello " + LoginForm.Globals.globalName;
            UMARSystemsProdLogDataSet.JobsDataTable tbl = new UMARSystemsProdLogDataSet.JobsDataTable();
            this.userIDTextBox.Text = userName;

        }

        private void jobsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            saveRecords();
        }

        private void ARProdLog_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'uMARSystemsProdLogDataSet.Jobs' table. You can move, or remove it, as needed.
            this.jobsTableAdapter.Fill(this.uMARSystemsProdLogDataSet.Jobs);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void saveRecords()
        {
            
            bool notSatisfied = true;

            while (notSatisfied)
            {
                try
                {
                    this.Validate();
                    this.jobsBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.uMARSystemsProdLogDataSet);
                    notSatisfied = false;
                }
                catch
                {
                    if (DialogResult.Retry == MessageBox.Show("Production Log cannot be Saved at this time", "Error Saving", MessageBoxButtons.RetryCancel))
                    {
                        notSatisfied = true;
                    }
                    else
                    {
                        notSatisfied = false;
                    }
                }
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            this.userIDTextBox.Text = userName;
        }

        #region linklabels
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string urlPath = "https://app.mt.gov/cgi-bin/umpayments/admin/index.cgi";
            OpenThings.openInternetExplorer(urlPath);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileExcelPath = "C:\\Users\\jonathan.forrider\\Documents\\Scripts\\Schedule\\ARtoFinanceReconCreation.xlsm";
            string fileAccessPath = "C:\\Users\\jonathan.forrider\\Documents\\Scripts\\Schedule\\Student_Jon.accdb";
            OpenThings.openExcelFile(fileExcelPath);
            OpenThings.openAccessFile(fileAccessPath);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string mb290Path = "J:\\All BusSrvcs Shared Folders\\AR Balancing Spreadsheets\\MB290 Deposit Reconciliations";
            OpenThings.openFileFolder(mb290Path);
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string fileAccessPath = "J:\\Databases\\Student\\Databases\\Student.accde";
            OpenThings.openAccessFile(fileAccessPath);
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string urlPath = "https://umt.app.box.com/files/0/f/3596453387/Job_Request_for_Business_Services";
            OpenThings.openInternetExplorer(urlPath);
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string urlPath = "https://inb.umt.edu:4445/forms/frmservlet?config=admn";
            OpenThings.openFirefox(urlPath);
        }
        #endregion
    }
}
