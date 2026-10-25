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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Tourism_Management
{
    public partial class Admin_Hotels : Form
    {
        BaseConnection con=new BaseConnection();
        public static string hid = "0";
        public Admin_Hotels()
        {
            InitializeComponent();
            fillcombo();
            get_hotelid();
            filldata();
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
        public void get_hotelid()

        {

            string query = "select isnull(max(hid),100)+1 from hotels";
            SqlDataReader dr = con.ret_dr(query);
            if (dr.Read())
            {
                hid = dr[0].ToString();
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
        public static string folderPath = Application.StartupPath + "\\hotels";
        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Application.StartupPath + "\\hotels");
            int filecount = files.Length;
            filecount = filecount + 1;
            string fileExtension = Path.GetExtension(textBox6.Text);
            string filename = hid + fileExtension;
            string newfilePath = folderPath + "\\" + filename;
            File.Copy(textBox6.Text, newfilePath);

            string query = "insert into hotels values(" + hid + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + ",'" + filename + "','"+comboBox1.Text+"')";
            if (con.exec1(query) > 0)
            {
                MessageBox.Show("Hotel Details added");
                this.Close();
            }
        }
        public void filldata()
        {
            string folderPath = Application.StartupPath + "\\hotels";

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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string q = "select * from destination where DestinationName='" + comboBox1.Text + "'";
            SqlDataReader dr = con.ret_dr(q);
            if (dr.Read())
            {
                textBox2.Text = dr[2].ToString();
                textBox3.Text = dr[3].ToString();
            }
        }
    }
}
