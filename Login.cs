using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wizard_Calculator
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            if (User.Text =="test"  && Password.Text =="test")
            {
                Calculator form = new Calculator();
                form.Show();
                FalsePasswordLabel.Text = ("");
                this.Close();
            }
            else
            {
                FalsePasswordLabel.Text = "The password is wrong!";
                MessageBox.Show("Username or password are incorrect!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
