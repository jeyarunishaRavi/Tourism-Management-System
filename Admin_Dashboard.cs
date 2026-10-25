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
    public partial class Admin_Dashboard : Form
    {
        BaseConnection con = new BaseConnection();
        public Admin_Dashboard()
        {
            InitializeComponent();
            filldata1();
            filldata2();
            filldata3();
            filldata4();
            filldata5();
            filldata6();
            filldata7();

        }

        public void filldata1()
        {
            string q = "select sum(amount) from Booking_Details";
            SqlDataReader dr = con.ret_dr(q);
            if (dr.Read())
            {
                label13.Text = dr[0].ToString();
            }
        }

        public void filldata2()
        {
            string q = "select count(bid) from Booking_Details";
            SqlDataReader dr = con.ret_dr(q);
            if (dr.Read())
            {
                label7.Text = dr[0].ToString();
            }
        }
        public void filldata3()
        {
            string q = "select count(DestinationID) from Destination";
            SqlDataReader dr = con.ret_dr(q);
            if (dr.Read())
            {
                label4.Text = dr[0].ToString();
            }
        }
        public void filldata4()
        {
            string q = "select count(hid) from hotels";
            SqlDataReader dr = con.ret_dr(q);
            if (dr.Read())
            {
                label2.Text = dr[0].ToString();
            }
        }
        public void filldata5()
        {
            string q = "select count(pid) from package_Details";
            SqlDataReader dr = con.ret_dr(q);
            if (dr.Read())
            {
                label5.Text = dr[0].ToString();
            }
        }

        public void filldata6()
        {
            string q = "select count(oid) from operator_details";
            SqlDataReader dr = con.ret_dr(q);
            if (dr.Read())
            {
                label11.Text = dr[0].ToString();
            }
        }
        public void filldata7()
        {
            string q = "select count(cid) from Customer_details";
            SqlDataReader dr = con.ret_dr(q);
            if (dr.Read())
            {
                label9.Text = dr[0].ToString();
            }
        }

    }
}
