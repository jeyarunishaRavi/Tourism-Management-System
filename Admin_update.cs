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
    public partial class Admin_update : Form
    {
        SqlConnection con = new SqlConnection("server=LAPTOP-QK3DTNDJ\\SQLEXPRESS;database=tourismdb;Integrated Security=True");

        public Admin_update()
        {
            InitializeComponent();
            fillcombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "update operator_details set company_name='"+textBox3.Text+"',address='"+textBox8.Text+"',contact="+textBox7.Text+",email='"+textBox6.Text+"',operator_name='"+textBox11.Text+"',operator_email='"+textBox10.Text+"',status='"+textBox9.Text+"',logo='"+textBox12.Text+"' where uid='"+comboBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Values Updated");
            }
            con.Close();
        }

        public void fillcombo()
        {
            //comboBox1.Items.Clear();
            string query = "select uid from operator_details";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            con.Close();

        }

        public void getdetails()
        {
            con.Open();
            string query = "select * from operator_details where uid='" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox3.Text = dr[2].ToString();
                textBox8.Text = dr[3].ToString();
                textBox7.Text = dr[4].ToString();
                textBox6.Text = dr[5].ToString();
                textBox11.Text = dr[6].ToString();
                textBox10.Text = dr[7].ToString();
                textBox9.Text = dr[8].ToString();
                textBox12.Text = dr[9].ToString();




            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdetails();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
