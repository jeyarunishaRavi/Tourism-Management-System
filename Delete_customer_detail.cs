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
    public partial class Delete_customer_detail : Form
    {
        SqlConnection con = Program.con;
        public Delete_customer_detail()
        {
            InitializeComponent();
            fillcombo();

        }

        public void fillcombo() 
        {
            //comboBox1.Items.Clear();
            string query = "select uid from operator_details";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr =cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            con.Close();

        }
        public void getdetails()
        {
            con.Open();
            string query = "select * from operator_details where uid='"+comboBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[2].ToString();
                textBox2.Text = dr[3].ToString();
                textBox3.Text = dr[6].ToString();


            }
            con.Close();
        }
        private void Delete_customer_detail_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdetails();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "delete from operator_details where uid='"+comboBox1.Text+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Customer Details deleted Successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";    
            }
            else {
                MessageBox.Show("Error while deleting Customer Data");
            }
            con.Close();
            fillcombo();
        }
    }
}
