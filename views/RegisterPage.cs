using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentalSystem2.Common;
using CarRentalSystem2.Handlers.CommandHandlers;
using CarRentalSystem2.Models;

namespace CarRentalSystem2.Views
{
    public partial class RegisterPage : Form
    {
        private UserAccountCommandHandler _accountCommand;
        private AuthenticationServices _authenticationServices;
        public RegisterPage()
        {
            InitializeComponent();
            _accountCommand = new UserAccountCommandHandler(Commons.ConnectionString);
            _authenticationServices = new AuthenticationServices(Commons.ConnectionString);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        
        
        private bool VerifyFormInputs()
        {
            return !string.IsNullOrWhiteSpace(txtPassword.Text) ||
                   !string.IsNullOrWhiteSpace(txtUsername.Text) ||
                   !string.IsNullOrWhiteSpace(txtVerifyPassword.Text);
        }

        private void ClearFields()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = String.Empty;
            txtVerifyPassword.Text = String.Empty;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!VerifyFormInputs())
            {
                lblErrorMessage.Text = "All fields must be filled out.";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
                return;
            }

            var userAccount = new UserAccount
            {
                UserName = txtUsername.Text,
                Password = txtPassword.Text,
                Role = cmbRole.SelectedItem.ToString()
            };
            
            _authenticationServices.SignUp(userAccount);
            ClearFields();
            MessageBox.Show("User Signed up Successfully");
            DialogResult = DialogResult.OK;
            Close();
        }

        private void txtVerifyPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string verify = txtVerifyPassword.Text;

            if (verify != password)
            {
                lblErrorMessage.Text = "Passwords do not match";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
                btnRegister.Enabled = false;
                return;
            }

            if (string.IsNullOrWhiteSpace(password) && !string.IsNullOrWhiteSpace(verify))
            {
                lblErrorMessage.Text = "Please enter password first";
                lblErrorMessage.ForeColor = Color.Red;
                lblErrorMessage.Visible = true;
                btnRegister.Enabled = false;
            }

            lblErrorMessage.Visible = false;
            btnRegister.Enabled = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
