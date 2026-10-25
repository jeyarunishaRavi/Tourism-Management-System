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
using System.Security.Cryptography;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tourism_Management
{
    public partial class Operator_Package : Form
    {
        BaseConnection con = new BaseConnection();
        public static string pid = "";
        public static string folderPath = Application.StartupPath + "\\package";
        public Operator_Package()
        {
            InitializeComponent();
            get_pid();
            fillcombo();
            filldata();
        }

        public void filldata()
        {
           

            imageList1.Images.Clear();
            listView1.Items.Clear();

            imageList1.ImageSize = new Size(100, 100);
            imageList1.ColorDepth = ColorDepth.Depth32Bit;

            listView1.LargeImageList = imageList1;
            listView1.View = View.LargeIcon;

            string[] files = Directory.GetFiles(folderPath, "*.*")
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                         || f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string file in files)
            {
                using (Image img = Image.FromFile(file))
                {
                    imageList1.Images.Add(new Bitmap(img));
                }

                listView1.Items.Add(
                    Path.GetFileNameWithoutExtension(file),
                    imageList1.Images.Count - 1
                );
            }
        }

        public void get_pid()
        {

            string query = "select isnull(max(pid),100)+1 from package_Details";
            SqlDataReader dr = con.ret_dr(query);
            if (dr.Read())
            {
                pid = dr[0].ToString();
            }

        }

        public void fillcombo()
        {
            comboBox1.Items.Clear();
            string query1 = "select DestinationName from Destination";
            SqlDataReader dr = con.ret_dr(query1);
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string query1 = "select HotelName from hotels where DestinationName='"+comboBox1.Text+"'";
            SqlDataReader dr = con.ret_dr(query1);
            while (dr.Read())
            {
                comboBox2.Items.Add(dr[0].ToString());

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            DialogResult result = openFileDialog1.ShowDialog();


            if (result == DialogResult.OK) // Test result.
            {
                textBox6.Text = openFileDialog1.FileName.ToString();
                pictureBox1.ImageLocation = textBox6.Text;


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Application.StartupPath + "\\package");
            int filecount = files.Length;
            filecount = filecount + 1;
            string fileExtension = Path.GetExtension(textBox6.Text);
            string filename = pid + fileExtension;
            string newfilePath = folderPath + "\\" + filename;
            File.Copy(textBox6.Text, newfilePath);
            string query = "insert into package_Details values(" + pid + ","+Program.oid+",'" + textBox1.Text + "','" + comboBox2.Text + "','" + textBox2.Text + "'," + textBox3.Text + ",'" + filename + "','" + comboBox2.Text + "')";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Package Details added");
                this.Close();
            }

        }
    }
}
