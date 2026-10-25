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
    public partial class Login : Form
    {
        SqlConnection con = Program.con;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "pwd")
            {
                MessageBox.Show("Login Success");
                Admin_Home obj = new Admin_Home();
                ActiveForm.Hide();
                obj.Show();
            }
            else {
                con.Open();
                string query = "select * from Login_details where username='"+textBox1.Text+"' and password='"+textBox2.Text+"'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Program.uid = dr[0].ToString();
                    if (dr[3].ToString()=="operator")
                    {
                        con.Close();
                        Operator_Homepage obj = new Operator_Homepage();
                        obj.Show();
                    }
                    else if (dr[3].ToString() == "customer")
                    {
                        con.Close() ;
                        Customer_Homepage obj = new Customer_Homepage();
                        obj.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid Input");
                    }
                    
                }
                con.Close();


            }

        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you a Operator?", "Confirmation",
     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               operator_description obj=new operator_description();
                obj.Show();
            }
            else
            {
               Customer_Registration obj=new Customer_Registration();
                obj.Show();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
