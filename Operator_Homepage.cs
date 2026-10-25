using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tourism_Management
{
    public partial class Operator_Homepage : Form
    {
        SqlConnection con = Program.con;
        public Operator_Homepage()
        {
            InitializeComponent();
            fillinfo();
        }
        public void fillinfo()
        {
            string query = "select uid,operator_name from operator_details where uid='" + Program.uid+"'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                label1.Text = "Welcome "+dr[1].ToString();

                Program.oid = dr[0].ToString();
            }
            con.Close();
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tourOperatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operator_Package obj = new Operator_Package();
            obj.Show();
        }

        private void destinationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Destinations obj = new Destinations();
            obj.Show();
        }

        private void hotelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hotels obj=new Hotels();
            obj.Show();
        }

        private void revenueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Operator_Bookings obj = new Operator_Bookings();
            obj.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            ActiveForm.Hide();
            obj.Show();
        }
    }
}
