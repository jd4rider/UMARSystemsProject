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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.uMARSystemsProdLogDataSet);

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'uMARSystemsProdLogDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.uMARSystemsProdLogDataSet.Users);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            UMARSystemsProdLogDataSet.UsersDataTable tbl = new UMARSystemsProdLogDataSet.UsersDataTable();
                        
            this.usersTableAdapter.Fill(tbl);
                                
            var res = from rowUsername in tbl.AsEnumerable() 
                      where rowUsername.Field<String>("Username") == userNameBox.Text
                      && rowUsername.Field<String>("Password") == passwordBox.Text
                      select rowUsername;

            //This is the lambda version -- var res = tbl.Where(c => c.Username == userNameBox.Text);

            var resResult = res.ToList();

            if (resResult.Any())
            {
                foreach (var item in res)
                {
                    var name = item.Username;
                    Globals.globalUsername = name;                                      
                    var firstLast = item.Namefirstlast;
                    Globals.globalName = firstLast;
                    if(DialogResult.OK == MessageBox.Show("Welcome " + firstLast))
                    {
                        this.Hide();
                        ARProdLog frm = new ARProdLog();
                        frm.Closed += (s, args) => this.Close();
                        frm.Show();
                    }
                }
            }
            else
            {
                MessageBox.Show("Incorrect Login", "Login Error");
            }

                     
             
        }

        public static class Globals
        {
            public static string globalUsername;
            public static string globalName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        



        /* private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            // Set to no text.
            passwordBox.Text = "";
            // The password character is an asterisk.
            passwordBox.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            passwordBox.MaxLength = 14;
        

        }*/
    }
}
