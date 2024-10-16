using System;
using System.Windows.Forms;
using CarRentalSystem2.Common;

namespace CarRentalSystem2.Views
{
    public partial class LoginPage : Form
    {
        private AuthenticationServices _auth;
        
        public LoginPage()
        {
            InitializeComponent();
            _auth = new AuthenticationServices(Commons.ConnectionString);
        }

        
        // ------------------------- Listener Functions ------------------------- \\
        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!VerifyFormInputs())
            {
                MessageBox.Show("Fields must not be empty!");
                return;
            }
            
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (_auth.Login(username, password))
            {
                MessageBox.Show("User Login Successful!");
                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Username and Password does not match!");
            }
        }
        
        
        // ------------------------- Helper Functions ------------------------- \\
        private bool VerifyFormInputs()
        {
            return !string.IsNullOrWhiteSpace(txtPassword.Text) ||
                   !string.IsNullOrWhiteSpace(txtUsername.Text);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Hide the current Login form
            Hide();

            // Create and show the Register form
            RegisterPage registerPage = new RegisterPage();
    
            // When the Register form is closed, show the Login form again
            registerPage.FormClosed += (s, args) => Show();

            // Show the Register form
            if (registerPage.ShowDialog() == DialogResult.OK)
            {
                registerPage.Close();
            }
            
            Show();
        }

        private void showRegister(object form)
        {
            Form f = form as Form;
            f.Show();
            // Close();
        }
    }
}
