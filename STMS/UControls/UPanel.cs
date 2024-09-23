using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STMS.UControls
{
    public partial class UPanel : UserControl
    {
       protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, Color.Green, Color.Blue, LinearGradientMode.Horizontal);
            g.FillRectangle(linearGradientBrush, rect);

        }
        public UPanel()
        {
            InitializeComponent();
        }
    }
}
