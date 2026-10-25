using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tourism_Management
{
    public partial class Admin_Destination : Form
    {
        BaseConnection con = new BaseConnection();
        public static string did = "";
        public Admin_Destination()
        {
            InitializeComponent();
            get_destinationid();
            filldata();
        }
        public static string folderPath = Application.StartupPath + "\\destination";
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
        public void get_destinationid()

        {
         
            string query = "select isnull(max(DestinationID),100)+1 from Destination";
           SqlDataReader dr=con.ret_dr(query);
            if (dr.Read())
            {
                did = dr[0].ToString();
            }
          
        }


        public void filldata()
        {
            string folderPath = Application.StartupPath + "\\destination";

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
        private void button1_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Application.StartupPath+ "\\destination");
            int filecount = files.Length;
            filecount = filecount + 1;
            string fileExtension = Path.GetExtension(textBox6.Text);
            string filename = did + fileExtension;
            string newfilePath = folderPath + "\\" + filename;
            File.Copy(textBox6.Text, newfilePath);

            string query = "insert into Destination values("+did+",'"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"',"+textBox5.Text+",'"+filename+"')";
            if (con.exec1(query)>0)
            {
                MessageBox.Show("Destination Details added");
                this.Close();
            }
        }
    }
}
