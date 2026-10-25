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

namespace Tourism_Management
{
    public partial class customer_details : Form
    {
        SqlConnection con=new SqlConnection("server=LAPTOP-B9IRCOE6\\SQLEXPRESS;database=tms;Integrated Security=True");
        public customer_details()
        {
            InitializeComponent();
        }

        private void getcustomer_details()
        {
            con.Open();
            string query = "select * from operator_details";
            SqlDataAdapter sda=new SqlDataAdapter(query,con);
            DataTable dt=new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void customer_details_Load(object sender, EventArgs e)
        {
            getcustomer_details();
        }
    }
}
