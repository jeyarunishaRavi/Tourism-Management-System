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
    public partial class Customer_orders : Form
    {
        BaseConnection con = new BaseConnection();
        public Customer_orders()
        {
            InitializeComponent();
            fillgrid();
            filldata();
            filldata3();
        }
        public void fillgrid()
        {
            string q1 = "select * from Booking_Details where cid='" + Program.cid + "'";
            DataSet ds = con.ret_ds(q1);
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
        }

        public void filldata()
        {
            string q = "select sum(amount) from Booking_Details where cid='" + Program.cid + "'";
            SqlDataReader dr = con.ret_dr(q);
            if (dr.Read())
            {
                label4.Text = dr[0].ToString();
            }
        }
        public void filldata3()
        {
            string q = "select count(bid) from Booking_Details where cid='" + Program.cid + "'";
            SqlDataReader dr = con.ret_dr(q);
            if (dr.Read())
            {
                label6.Text = dr[0].ToString();
            }
        }
    }
}
