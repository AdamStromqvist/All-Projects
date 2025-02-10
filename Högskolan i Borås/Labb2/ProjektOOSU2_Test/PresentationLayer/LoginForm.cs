using ProjektOOSU2_Test.BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektOOSU2_Test.PresentationLayer
{

//Class for the login form
    public partial class LoginForm : Form
    {
        private readonly IEmployeeService _employeeService;

        public LoginForm(IEmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private async void buttonSignIn_Click(object sender, EventArgs e)
        {
            var username = textBoxUsername.Text;
            var password = textBoxPassword.Text;
            var isValidUser = await _employeeService.ValidateLoginAsync(username, password);

            if (isValidUser)
            {
                // Log in user and open the main form
                this.Hide(); // Hides the loginform
                var mainForm = new MainForm(); // Log in the user and open the main application form
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Felaktigt användarnamn eller lösenord", "Inloggningsfel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
