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
using System.IO;

namespace Tourism_Management
{
    public partial class Customer_Select_Package : Form
    {
        BaseConnection con = new BaseConnection();
        public Customer_Select_Package()
        {
            InitializeComponent();
            filldata();
        }
        public void filldata()
        {
            string folderPath = Application.StartupPath + "\\package";

            imageList1.Images.Clear();
            listView1.Items.Clear();

            imageList1.ImageSize = new Size(200,200);
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string name = listView1.SelectedItems[0].Text;

                Customer_Confirm obj = new Customer_Confirm(name);
                ActiveForm.Hide();
                obj.Show();
            }
        }
    }
}
