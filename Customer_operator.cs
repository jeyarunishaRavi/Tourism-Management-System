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
    public partial class Customer_operator : Form
    {
        BaseConnection con = new BaseConnection();
        public Customer_operator()
        {
            InitializeComponent();
            fillgrid();
        }
        public void fillgrid()
        {
            string q1 = "select * from operator_details";
            DataSet ds = con.ret_ds(q1);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
