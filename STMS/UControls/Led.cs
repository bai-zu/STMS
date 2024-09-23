using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace STMS
{
    public partial class Led : Label
    {
        public Led()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SizeChanged += OvalLabel_SizeChanged;
        }
        Rectangle rect;
        private void OvalLabel_SizeChanged(object sender, EventArgs e)
        {
            rect = new Rectangle(0, 0, this.Width, this.Height);
            this.Region = new Region(rect);
            rect.Width -= 1;
            rect.Height -= 1;
        }

        //边框宽度
        private int borderWidth = 1;

        public int BorderWidth
        {
            get { return borderWidth; }
            set { borderWidth = value; Invalidate(); }
        }

        //边框颜色
        private Color borderColor = Color.Black;

        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        //中心颜色
        private Color centorColor = Color.LightGray;

        public Color CentorColor
        {
            get { return centorColor; }
            set { centorColor = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //设置绘图区域
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(this.ClientRectangle);
            this.Region = new Region(path);

            //获取绘图对象
            Graphics g = e.Graphics;
            //呈现质量设置为高质量
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;//HighQuality和AntiAlias执行效果相同
            //获取边框内中心椭圆的矩形绘图区域
            Rectangle innerRect = new Rectangle(rect.X + borderWidth, rect.Y + borderWidth, rect.Width - 2 * borderWidth, rect.Height - 2 * borderWidth);

            //填充边框
            g.FillEllipse(new SolidBrush(borderColor), rect);
            //填充中心
            g.FillEllipse(new SolidBrush(CentorColor), innerRect);

            this.AutoSize = false;
            this.BackColor = Color.Transparent;
            this.TextAlign = ContentAlignment.MiddleCenter;
            base.OnPaint(e);
        }
    }
}
