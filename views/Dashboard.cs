using CarRentalSystem2.TestViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem2.Views
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void LoadForm(object form)
        {
            if (pnlMain.Controls.Count > 0)
                pnlMain.Controls.RemoveAt(0);

            Form f = form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(f);
            pnlMain.Tag = f;
            f.Show();
        }


        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadForm(new HomePage());
        }

        private void btnAvailableCars_Click(object sender, EventArgs e)
        {
            LoadForm(new AvailableCarsPage());
        }

        private void btnRentCar_Click(object sender, EventArgs e)
        {
            LoadForm(new RentCarPage());
        }

        private void btnInquiry_Click(object sender, EventArgs e)
        {
            LoadForm(new InquiryPage(pnlMain));
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            LoadForm(new CustomerPage());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bFormDragDashboard_FormDragging(object sender,
            Bunifu.UI.WinForms.BunifuFormDrag.FormDraggingEventArgs e)
        {
        }
    }
}