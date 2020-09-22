using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Furie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, 10);

            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new System.Drawing.Font(FontFamily.GenericSerif, 3f);

            int Ampl; // максимальная амплитуда графиков
            int Period;
            const int Num = 16; // количество графиков
            int u, j, v, k;
            double arg;
            String text;
            int PX, PY=0, predPY;
            int Xmin, Xmax, Ymin, Ymax, Ybegin, Yend;
            Ampl = this.Height / Num - 4;
            Ybegin = 0; Yend = this.Height;
            Period = 1;
            Xmin = 0; Xmax = Num * Period;
            Ymin = -1; Ymax = 1;
            u = 0; v = 0;
            for (int i = 1; i <= Num; i++)
            {
                e.Graphics.DrawString(i.ToString(), font, brush, 0, Ybegin);
                Pen pen = new Pen(Color.Red, 0.5f);
                e.Graphics.DrawLine(pen, 0, Ybegin + Ampl/2, this.Width / 2 - 16, Ybegin + Ampl/2);
                pen.Color = Color.Black;
                for (PX = 0; PX <= this.Width / 2 - 16; PX++)
                {
                    j = Xmin + PX * (Xmax - Xmin) / (this.Width / 2 - 16);
                    arg = 2 * Math.PI * j * i / Num;
                    text = j.ToString();
                    arg = Math.Sin(arg);
                    double ppy = Ybegin + Ampl - (arg - Ymin) * Ampl / (Ymax - Ymin);
                    predPY = PY;
                    PY = (int)ppy;
                    e.Graphics.DrawLine(pen, PX-1, predPY, PX, PY);
                    if ((j != u) && (i == 1)) e.Graphics.DrawString(text, font, brush, PX, PY);
                    u = j;
                }
                //-------- cos -----------
                e.Graphics.DrawString(i.ToString(), font, brush, this.Width / 2, Ybegin);
                pen.Color = Color.Red;
                e.Graphics.DrawLine(pen, this.Width / 2, Ybegin + Ampl / 2, this.Width, Ybegin + Ampl / 2);
                pen.Color = Color.Black;
                for (PX = this.Width / 2; PX <= this.Width; PX++)
                {
                    j = Xmin + PX * (Xmax - Xmin) / (this.Width / 2 - 8) - 16;
                    arg = 2 * 3.14 * j * i / Num;
                    text = j.ToString();
                    arg = Math.Cos(arg);
                    double ppy = Ybegin + Ampl - (arg - Ymin) * Ampl / (Ymax - Ymin);
                    predPY = PY;
                    PY = (int)ppy;
                    e.Graphics.DrawLine(pen, PX-1, predPY, PX, PY);
                    if ((v != j) && (i == 1)) e.Graphics.DrawString(text, font, brush, PX, PY);
                    v = j;
                }
                Ybegin += Ampl + 1;
            }

        }
    }
}
