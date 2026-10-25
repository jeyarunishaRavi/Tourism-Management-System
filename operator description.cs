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
    public partial class operator_description : Form
    {
        SqlConnection con = Program.con;

        public operator_description()
        {
            InitializeComponent();
        }
        public void get_userid()
        {
            con.Open();
            string query = "select isnull(max(uid),100)+1 from login_details";
            SqlCommand cmd = new SqlCommand(query,con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr[0].ToString();
            }
            con.Close();
        }

        private void operator_description_Load(object sender, EventArgs e)
        {
            get_userid();
            get_operatorid();
           
        }
        public void get_operatorid()
        {
            con.Open();
            string query = "select isnull(max(oid),100)+1 from operator_details";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "insert into Login_details values("+textBox2.Text+",'"+textBox5.Text+"','"+textBox4.Text+"','operator')";
            string query2 = "insert into operator_details values("+textBox1.Text+","+textBox2.Text+",'"+textBox3.Text+"','"+textBox8.Text+"',"+textBox7.Text+",'"+textBox6.Text+"','"+textBox11.Text+"','"+textBox10.Text+"','Active','')";
            SqlCommand cmd1=new SqlCommand(query,con);
            SqlCommand cmd2=new SqlCommand(query2,con);

            if (cmd1.ExecuteNonQuery() > 0)
            {
                if (cmd2.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Registration Success");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox8.Text = "";
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox11.Text = "";
                    textBox10.Text = "";
                   
                   
                    textBox4.Text = "";
                    textBox5.Text = "";
                    ActiveForm.Hide();
                }
            }
            else {
                MessageBox.Show("Registration Failed");
            }
            con.Close() ;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }


        
    }
}
