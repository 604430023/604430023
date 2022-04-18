using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parallel_three_axis_robot_2016_11_21
{
    public partial class Form2 : Form
    {
        Form1 form;
        public Form2(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (form != null)
            {
                form.applyfilter(trackBar1.Value, trackBar2.Value);
                //Console.WriteLine("Min={0:d} , Max={1:d}",trackBar1.Value,trackBar2.Value);
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (form != null)
            {
                form.applyfilter(trackBar1.Value, trackBar2.Value);
                //Console.WriteLine("Min={0:d} , Max={1:d}", trackBar1.Value, trackBar2.Value);
            }
        }
    }
}
