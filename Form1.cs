using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7_2
{
    public partial class Form1 : Form
    {
        private colorBox box;
        ToolTip toolTip1 = new ToolTip();
        public Form1()
        {
            InitializeComponent();
            label1.Text = trackBar1.Value.ToString();
            label2.Text = trackBar2.Value.ToString();
            label3.Text = trackBar3.Value.ToString();
            box = new colorBox(trackBar1.Value, trackBar2.Value, trackBar3.Value, panel1);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
           
        }

        private void trackBar3_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = trackBar3.Value.ToString();
            box.changeGreenColor(trackBar3.Value);
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
            box.changeBlueColor(trackBar2.Value);
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
            box.changeRedColor(trackBar1.Value);
        }

        private class colorBox
        {
            int R;
            int G;
            int B;
            Panel box;
            public colorBox(int Red, int Green, int Blue, Panel box)
            {
                R = Red;
                G = Green;
                B = Blue;
                this.box = box;
                box.BackColor = Color.FromArgb(255, R, G, B);
            }

            public void changeRedColor(int Red)
            {
                R = Red;
                box.BackColor = Color.FromArgb(255, R, G, B);
                Clipboard.SetText(getColorHex());
            }

            public void changeGreenColor(int Green)
            {
                G = Green;
                box.BackColor = Color.FromArgb(255, R, G, B);
                Clipboard.SetText(getColorHex());
            }

            public void changeBlueColor(int Blue)
            {
                B = Blue;
                box.BackColor = Color.FromArgb(255, R, G, B);
                Clipboard.SetText(getColorHex());
            }

            public string getColorHex()
            {
          
                return ColorTranslator.ToHtml(box.BackColor).ToString();
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            // Create the ToolTip and associate with the Form container.
           

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 1000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.panel1, box.getColorHex());
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.RemoveAll();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
