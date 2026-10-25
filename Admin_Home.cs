using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tourism_Management
{
    public partial class Admin_Home : Form
    {
        public Admin_Home()
        {
            InitializeComponent();
        }

        private void Admin_Home_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            customer_details obj = new customer_details();
            obj.Show();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customer_details obj = new customer_details();
            ActiveForm.Hide();
            obj.Show();
        }

        private void deleteCustomerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_customer_detail obj = new Delete_customer_detail();
            ActiveForm.Hide();
            obj.Show();
        }

        private void updateCustomerDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_update obj = new Admin_update();
            ActiveForm.Hide();
            obj.Show();
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tourOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Admin_Operator obj=new Admin_Operator();
           
            obj.Show();
        }

        private void destinationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_Destination obj = new Admin_Destination();
            obj.Show();
        }

        private void hotelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_Hotels obj = new Admin_Hotels();
            obj.Show();
        }

        private void revenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_Dashboard obj = new Admin_Dashboard();
            obj.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
        }
    }
}
