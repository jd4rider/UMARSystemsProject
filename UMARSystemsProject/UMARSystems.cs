using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UMARSystemsProject
{
    public partial class UMARSystems : Form
    {
        public UMARSystems()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'uMARSystemsProdLogDataSet.Tasks' table. You can move, or remove it, as needed.
            this.tasksTableAdapter.Fill(this.uMARSystemsProdLogDataSet.Tasks);
            // TODO: This line of code loads data into the 'uMARSystemsProdLogDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.uMARSystemsProdLogDataSet.Users);


        }

        public void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to Save before Exiting?", "Exit without Saving", MessageBoxButtons.YesNoCancel);

            if (dr == DialogResult.No)
            {
                Environment.Exit(0);
            }
            else if (dr == DialogResult.Yes)
            {
                bool notSatisfied = true;

                while (notSatisfied)
                {
                    try
                    {
                        this.Validate();
                        this.usersBindingSource.EndEdit();
                        this.tasksBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.uMARSystemsProdLogDataSet);
                        MessageBox.Show("The Production Log has been Saved Successfully");
                        notSatisfied = false;
                        Environment.Exit(0);
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
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool notSatisfied = true;

            while (notSatisfied)
            {
                try
                {
                    this.Validate();
                    this.usersBindingSource.EndEdit();
                    this.tasksBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.uMARSystemsProdLogDataSet);
                    notSatisfied = false;
                    MessageBox.Show("Production Log has been Saved Successfully");
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

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            bool notSatisfied = true;

            while (notSatisfied)
            {
                try
                {
                    this.Validate();
                    this.usersBindingSource.EndEdit();
                    this.tasksBindingSource.EndEdit();
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



        private void saveAsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            closeItemsofType();
        }

        private void completeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tasksDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PageTwoGoto_Click(object sender, EventArgs e)
        {
            closeItemsofType();
        }
        public void closeItemsofType()
        {
            bool notSatisfied = true;

            while (notSatisfied)
            {
                if (DialogResult.Yes == MessageBox.Show("Do you want to Save and Exit?", "Save and Exit", MessageBoxButtons.YesNo))
                {
                    try
                    {
                        this.Validate();
                        this.usersBindingSource.EndEdit();
                        this.tasksBindingSource.EndEdit();
                        this.tableAdapterManager.UpdateAll(this.uMARSystemsProdLogDataSet);
                        MessageBox.Show("The Production Log has been Saved Successfully");
                        notSatisfied = false;
                        Environment.Exit(0);
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
                else
                {
                    notSatisfied = false;
                }
            }
        }
    }
} 
