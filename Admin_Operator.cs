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
    public partial class Admin_Operator : Form
    {
        BaseConnection con=new BaseConnection();
        
        public Admin_Operator()
        {
            InitializeComponent();
            fillgrid();
            fillcombo();
        }
        public void fillcombo()
        {
            comboBox1.Items.Clear();
            string query1 = "select oid from operator_details where status='Active'";
            SqlDataReader dr = con.ret_dr(query1);
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }


        }
        public void fillgrid()
        {
            string q1 = "select * from operator_details";
            DataSet ds = con.ret_ds(q1);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string q1 = "select * from operator_details where oid='"+comboBox1.Text+"'";
            DataSet ds = con.ret_ds(q1);
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string q = "update operator_details set status='Inactive' where oid='" + comboBox1.Text + "'";
            if(con.exec1(q)>0)
            {
                MessageBox.Show("Operator Blocked");
                this.Close();
            }
        }
    }
}
