using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMARSystemsLibraries
{
    public class Class1
    {
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
