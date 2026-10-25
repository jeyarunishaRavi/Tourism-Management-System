using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace Tourism_Management
{
    public partial class Customer_Confirm : Form
    {
        BaseConnection con = new BaseConnection();
        public static string pid = "";
        public static string cid = "";
        public static string oid = "";
        public static string bid = "";
        public Customer_Confirm()
        {
            InitializeComponent();
        }
        public Customer_Confirm(string id)
        {
            InitializeComponent();
            pid= id;
            filldata(id);
            get_bookingid();
            cid = Program.cid;
            get_operatorid(id);
        }
        public void get_operatorid(string id)
        {

            string query = "select oid from package_Details where pid='"+id+"'";
            SqlDataReader dr = con.ret_dr(query);
            if (dr.Read())
            {
                oid = dr[0].ToString();
            }

        }

        public void get_bookingid()
        {

            string query = "select isnull(max(bid),100)+1 from Booking_Details";
            SqlDataReader dr = con.ret_dr(query);
            if (dr.Read())
            {
                bid = dr[0].ToString();
            }

        }
        public void filldata(string id)
        {
            string query1 = "select * from package_Details where pid='" + id + "'";
            SqlDataReader dr = con.ret_dr(query1);
            if (dr.Read())
            {
                textBox1.Text = dr[2].ToString();
                textBox4.Text = dr[3].ToString();
                textBox5.Text = dr[7].ToString();
                textBox2.Text = dr[4].ToString();
                textBox3.Text = dr[5].ToString();
                pictureBox1.ImageLocation = Application.StartupPath + "\\package\\" + dr[6].ToString();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label9.Text = (Convert.ToInt32(textBox6.Text) *
               Convert.ToInt32(textBox3.Text)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = System.DateTime.Now.ToShortDateString();
            string q = "insert into Booking_Details values(" + bid + ",'" + oid + "','" + cid + "','" + pid + "','" + dateTimePicker1.Text + "'," + textBox6.Text + "," + label9.Text + ",'" + date + "')";
            if(con.exec1(q)>0)
            {
                MessageBox.Show("Booking confirmed...");
                this.Close();
            }
        }
    }
}
