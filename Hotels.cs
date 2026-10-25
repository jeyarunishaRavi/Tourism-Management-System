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
    public partial class Hotels : Form
    {
        BaseConnection con=new BaseConnection();
        public Hotels()
        {
            InitializeComponent();
            filldata();
            fillgrid();
        }
        public void fillgrid()
        {
            string q1 = "select * from Hotels";
            DataSet ds = con.ret_ds(q1);
            dataGridView2.DataSource = ds.Tables[0].DefaultView;
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
    }
}
