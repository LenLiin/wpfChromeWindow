using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string imgurl = "http://img.zcool.cn/community/0117e2571b8b246ac72538120dd8a4.jpg@1280w_1l_2o_100sh.jpg";

            Image img;
            WebRequest request = WebRequest.Create(imgurl);
            using (WebResponse response = request.GetResponse())
            {
                img = Image.FromStream(response.GetResponseStream());
            }
            pictureBox1.BackgroundImage = img;
        }
    }
}
