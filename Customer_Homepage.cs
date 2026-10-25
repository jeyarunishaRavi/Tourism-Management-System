using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tourism_Management
{
   
    public partial class Customer_Homepage : Form
    {
        BaseConnection con = new BaseConnection();
        public Customer_Homepage()
        {
            InitializeComponent();
            fillinfo();
        }
       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tourOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
         Customer_Select_Package obj=new Customer_Select_Package();
            obj.Show();
        }

        private void destinationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Destinations obj=new Destinations();
            obj.Show();
        }

        private void hotelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hotels obj = new Hotels();
            obj.Show();
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            ActiveForm.Hide();
            obj.Show();
        }

        public void fillinfo()
        {
            string query = "select cid,name from Customer_details where uid='" + Program.uid + "'";
            SqlDataReader dr = con.ret_dr(query);
            while (dr.Read())
            {
                label1.Text = "Welcome " + dr[1].ToString();

                Program.cid = dr[0].ToString();
            }
           
        }

        private void revenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer_orders obj=new Customer_orders();
            obj.Show();
        }
    }
}
