using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace KPI
{
    public class LoadingCircle : Control
    {
        private System.Windows.Forms.Timer timer;  // Explicitly specify WinForms Timer
        private int angle;

        public LoadingCircle()
        {
            this.DoubleBuffered = true;
            this.timer = new System.Windows.Forms.Timer { Interval = 100 };
            this.timer.Tick += (s, e) => { angle += 30; this.Invalidate(); };
        }

        public void Start() => timer.Start();
        public void Stop() => timer.Stop();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            for (int i = 0; i < 12; i++)
            {
                int alpha = (255 * (i + 1)) / 12;
                using (Brush brush = new SolidBrush(Color.FromArgb(alpha, Color.Black)))
                {
                    double radian = (angle + i * 30) * Math.PI / 180;
                    float x = (float)(Width / 2 + Math.Cos(radian) * Width / 3);
                    float y = (float)(Height / 2 + Math.Sin(radian) * Height / 3);
                    e.Graphics.FillEllipse(brush, x - 5, y - 5, 10, 10);
                }
            }
        }
    }
}

