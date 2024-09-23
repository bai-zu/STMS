using Google.Protobuf.WellKnownTypes;
using STMS.UControls;
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
    public partial class Thermometer : UserControl
    {
        public delegate void EventHandler(object sender, TemperatureEventArgs e);

        private readonly int angle = 45;
        private readonly int paddingBottom = 10;
        private readonly int paddingTop = 10;
        private readonly int paddingRight = 6;
        private readonly int paddingLeft = 6;
        private readonly int lineExtent = 10;

        #region

        private event EventHandler valueChanged;
        /// <summary>
        /// 温度值更改事件
        /// </summary>
        [Description("温度值更改事件")]
        public event EventHandler ValueChanged
        {
            add { this.valueChanged += value; }
            remove { this.valueChanged -= value; }
        }

        private int circleRadius = 10;
        /// <summary>
        /// 温度计圆点半径
        /// </summary>
        [DefaultValue(10)]
        [Description("温度计圆点半径")]
        public int CircleRadius
        {
            get { return this.circleRadius; }
            set
            {
                if (this.circleRadius == value)
                    return;
                this.circleRadius = value;
                this.Invalidate();
            }
        }

        private bool textShow = true;
        /// <summary>
        /// 是否显示文本
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示文本")]
        public bool TextShow
        {
            get { return this.textShow; }
            set
            {
                if (this.textShow == value)
                    return;
                this.textShow = value;
                this.Invalidate();
            }
        }

        private bool scaleShow = true;
        /// <summary>
        /// 是否显示刻度线
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示刻度线")]
        public bool ScaleShow
        {
            get { return this.scaleShow; }
            set
            {
                if (this.scaleShow == value)
                    return;
                this.scaleShow = value;
                this.Invalidate();
            }
        }

        private ScaleDirection scaleDirectionType = ScaleDirection.Left;
        /// <summary>
        /// 刻度线显示位置
        /// </summary>
        [DefaultValue(ScaleDirection.Left)]
        [Description("刻度线显示位置")]
        public ScaleDirection ScaleDirectionType
        {
            get { return this.scaleDirectionType; }
            set
            {
                if (this.scaleDirectionType == value)
                    return;
                this.scaleDirectionType = value;
                this.Invalidate();
            }
        }

        private Color scaleLineColor = Color.DimGray;
        /// <summary>
        /// 刻度线颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DimGray")]
        [Description("刻度线颜色")]
        public Color ScaleLineColor
        {
            get { return this.scaleLineColor; }
            set
            {
                if (this.scaleLineColor == value)
                    return;
                this.scaleLineColor = value;
                this.Invalidate();
            }
        }

        private int scaleCutCount = 5;
        /// <summary>
        /// 一个间隔刻度分割成多少个子刻度
        /// </summary>
        [DefaultValue(5)]
        [Description("一个间隔刻度分割成多少个子刻度")]
        public int ScaleCutCount
        {
            get { return this.scaleCutCount; }
            set
            {
                if (this.scaleCutCount == value || value < 1)
                    return;
                this.scaleCutCount = value;
                this.Invalidate();
            }
        }

        private Color scaleCutLineColor = Color.DimGray;
        /// <summary>
        /// 子刻度颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DimGray")]
        [Description("子刻度颜色")]
        public Color TcaleCutLineColor
        {
            get { return this.scaleCutLineColor; }
            set
            {
                if (this.scaleCutLineColor == value)
                    return;
                this.scaleCutLineColor = value;
                this.Invalidate();
            }
        }

        private bool scaleTextShow = true;
        /// <summary>
        /// 是否显示刻度线值
        /// </summary>
        [DefaultValue(true)]
        [Description("是否显示刻度线值")]
        public bool ScaleTextShow
        {
            get { return this.scaleTextShow; }
            set
            {
                if (this.scaleTextShow == value)
                    return;
                this.scaleTextShow = value;
                this.Invalidate();
            }
        }

        private Font scaleTextFont = new Font("宋体", 10);
        /// <summary>
        /// 刻度线值字体
        /// </summary>
        [DefaultValue(typeof(Font), "宋体, 10pt")]
        [Description("刻度线值字体")]
        public Font ScaleTextFont
        {
            get { return this.scaleTextFont; }
            set
            {
                if (this.scaleTextFont == value)
                    return;
                this.scaleTextFont = value;
                this.Invalidate();
            }
        }

        private Color scaleTextColor = Color.DimGray;
        /// <summary>
        /// 刻度线文字颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DimGray")]
        [Description("刻度线文字颜色")]
        public Color ScaleTextColor
        {
            get { return this.scaleTextColor; }
            set
            {
                if (this.scaleTextColor == value)
                    return;
                this.scaleTextColor = value;
                this.Invalidate();
            }
        }

        private float intervalValue = 10f;
        /// <summary>
        /// 间隔刻度大小
        /// </summary>
        [DefaultValue(10f)]
        [Description("间隔刻度大小")]
        public float IntervalValue
        {
            get { return this.intervalValue; }
            set
            {
                if (this.intervalValue == value)
                    return;
                this.intervalValue = value;
                this.Invalidate();
            }
        }

        private int borderWidth = 3;
        /// <summary>
        /// 边框宽度
        /// </summary>
        [DefaultValue(3)]
        [Description("边框宽度")]
        public int BorderWidth
        {
            get { return this.borderWidth; }
            set
            {
                if (this.borderWidth == value)
                    return;
                this.borderWidth = value;
                this.Invalidate();
            }
        }

        private Color borderColor = Color.DimGray;
        /// <summary>
        /// 边框颜色
        /// </summary>
        [DefaultValue(typeof(Color), "DimGray")]
        [Description("边框颜色")]
        public Color BorderColor
        {
            get { return this.borderColor; }
            set
            {
                if (this.borderColor == value)
                    return;
                this.borderColor = value;
                this.Invalidate();
            }
        }

        private Color valueColor = Color.Tomato;
        /// <summary>
        /// 值颜色
        /// </summary>
        [DefaultValue(typeof(Color), "Tomato")]
        [Description("值颜色")]
        public Color ValueColor
        {
            get { return this.valueColor; }
            set
            {
                if (this.valueColor == value)
                    return;
                this.valueColor = value;
                this.Invalidate();
            }
        }

        private float maxValue = 100f;
        /// <summary>
        /// 最大值
        /// </summary>
        [DefaultValue(100f)]
        [Description("最大值")]
        public float MaxValue
        {
            get { return this.maxValue; }
            set
            {
                if (this.maxValue == value || value < this.minValue)
                    return;
                this.maxValue = value;
                this.Invalidate();
            }
        }

        private float minValue = -20f;
        /// <summary>
        /// 最小值
        /// </summary>
        [DefaultValue(-20f)]
        [Description("最小值")]
        public float MinValue
        {
            get { return this.minValue; }
            set
            {
                if (this.minValue == value || value > this.maxValue)
                    return;
                this.minValue = value;
                this.Invalidate();
            }
        }

        private float value = 0f;
        /// <summary>
        /// 当前值
        /// </summary>
        [DefaultValue(0f)]
        [Description("当前值")]
        public float Value
        {
            get { return this.value; }
            set
            {
                if (this.value == value)
                    return;
                this.value = value;
                if (this.valueChanged != null)
                {
                    this.valueChanged(this, new TemperatureEventArgs() { Value = value });
                }
                this.Invalidate();
            }
        }

        public new string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text == value)
                    return;
                base.Text = value;
                this.Invalidate();
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(60, 400);
            }
        }

        #endregion

        public Thermometer()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            SmoothingMode sm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int diameter = this.circleRadius * 2;
            Rectangle bounds_rect = e.ClipRectangle;
            RectangleF text_rect = new RectangleF(0, 0, 0, 0);//文本rect
            if (this.TextShow)
            {
                SizeF text_size = g.MeasureString(this.Text, this.Font);
                text_rect.Width = text_size.Width;
                text_rect.Height = text_size.Height;
                text_rect.X = bounds_rect.X + ((float)bounds_rect.Width - text_size.Width) / 2;
                text_rect.Y = bounds_rect.Bottom - text_size.Height;
            }
            float scale_width = (float)Math.Sqrt(Math.Pow(this.CircleRadius, 2) * 2);//温度计刻度部分rect的宽度
            float scale_height = bounds_rect.Height - this.paddingBottom - text_rect.Height - this.CircleRadius - scale_width / 2 - scale_width / 2 - this.paddingTop;
            Rectangle circle_rect = new Rectangle(this.paddingLeft, bounds_rect.Bottom - this.paddingBottom - (int)text_rect.Height - diameter, diameter, diameter);//圆的rect
            if (this.scaleDirectionType == ScaleDirection.Right)
            {
                circle_rect.X = bounds_rect.Right - this.paddingRight - diameter;
            }
            RectangleF scale_rect = new RectangleF(circle_rect.X + (this.circleRadius - scale_width / 2), bounds_rect.Y + this.paddingTop + scale_width / 2, scale_width, scale_height);//温度计刻度部分rect

            float sumValue = 0;
            if (this.MaxValue > 0 && this.MinValue >= 0)
            {
                sumValue = this.MaxValue - this.MinValue;
            }
            else if (this.MaxValue > 0 && this.MinValue < 0)
            {
                sumValue = this.MaxValue - this.MinValue;
            }
            else if (this.MaxValue < 0 && this.MinValue < 0)
            {
                sumValue = Math.Abs(this.MinValue) - Math.Abs(this.MaxValue);
            }

            #region Text
            if (this.TextShow)
            {
                SolidBrush text_sb = new SolidBrush(this.ForeColor);
                g.DrawString(this.Text, this.Font, text_sb, text_rect.X, text_rect.Y);
                text_sb.Dispose();
            }
            #endregion

            #region 值背景
            SolidBrush value_sb = new SolidBrush(this.ValueColor);
            GraphicsPath value_gp = new GraphicsPath();
            value_gp.AddArc(circle_rect, 270 + (90 - this.angle), 360 - (90 - this.angle) * 2);
            if (this.Value < this.MaxValue)
            {
                float x = circle_rect.X + (circle_rect.Width - scale_width) / 2;
                float y = scale_rect.Bottom - scale_height / (sumValue / (this.Value + Math.Abs(this.MinValue)));
                value_gp.AddLine(x, y, x + scale_width, y);
            }
            else
            {
                float x = circle_rect.X + (circle_rect.Width - scale_width) / 2;
                float y = this.paddingTop;
                value_gp.AddArc(new RectangleF(x, y, scale_width, scale_width), 180, 180);
            }
            value_gp.CloseFigure();
            g.FillPath(value_sb, value_gp);
            value_gp.Dispose();
            value_sb.Dispose();
            #endregion

            #region 边框
            Pen border_pen = new Pen(this.BorderColor, this.BorderWidth);
            GraphicsPath border_gp = new GraphicsPath();
            border_gp.AddArc(circle_rect, 270 + (90 - this.angle), 360 - (90 - this.angle) * 2);
            border_gp.AddArc(new RectangleF(circle_rect.X + (circle_rect.Width - scale_width) / 2, this.paddingTop, scale_width, scale_width), 180, 180);
            border_gp.CloseFigure();
            g.DrawPath(border_pen, border_gp);
            border_gp.Dispose();
            border_pen.Dispose();
            #endregion

            g.SmoothingMode = sm;

            #region  刻度

            if (this.ScaleShow)
            {
                Pen scaleLine_pen = new Pen(this.ScaleLineColor, 2);
                Pen scaleCutLine_pen = new Pen(this.scaleCutLineColor, 1);
                SolidBrush scaleLineText_sb = new SolidBrush(this.ScaleTextColor);

                float maxValueYU = Math.Abs(this.MaxValue % this.IntervalValue);
                float minValueYU = Math.Abs(this.MinValue % this.IntervalValue);
                int count = 0;
                float v = sumValue;
                if (maxValueYU != 0)
                    v -= maxValueYU;
                if (minValueYU != 0)
                    v -= minValueYU;
                count = (int)(v / this.IntervalValue);//分了多少个间隔

                //count*pixel+(maxValueYU/this.TickFrequency)*pixel+(minValueYU/this.TickFrequency)*pixel=scale_height;
                float pixel = scale_height / (count + maxValueYU / this.IntervalValue + minValueYU / this.IntervalValue);//一个间隔代表像素

                if (maxValueYU != 0)
                    count++;
                if (minValueYU != 0)
                    count++;
                float line_y = scale_rect.Bottom;
                float str = 0;
                for (int i = 0; i <= count; i++)
                {
                    if (i == 0)
                    {
                        str = this.MinValue;
                    }
                    else if (i == 1)
                    {
                        if (minValueYU != 0)
                        {
                            line_y -= (minValueYU / this.IntervalValue) * pixel;
                            str += minValueYU;
                        }
                        else
                        {
                            line_y -= pixel;
                            str += this.IntervalValue;
                        }
                    }
                    else if (i == count)
                    {
                        if (maxValueYU != 0)
                        {
                            line_y -= (maxValueYU / this.IntervalValue) * pixel;
                            str += maxValueYU;
                        }
                        else
                        {
                            line_y -= pixel;
                            str += this.IntervalValue;
                        }
                    }
                    else
                    {
                        line_y -= pixel;
                        str += this.IntervalValue;
                    }
                    float line_x1 = scale_rect.Right;
                    float line_x2 = scale_rect.Right + this.lineExtent;
                    if (this.scaleDirectionType == ScaleDirection.Right)
                    {
                        line_x1 = scale_rect.X - this.lineExtent;
                        line_x2 = scale_rect.X;
                    }
                    g.DrawLine(scaleLine_pen, line_x1, line_y, line_x2, line_y);


                    #region 子刻度线
                    if (this.ScaleCutCount > 1)
                    {
                        float group_y = line_y;
                        if (!((i == 0) || (i == 1 && minValueYU != 0) || (i == count && maxValueYU != 0)))//排除第一个和不完整的
                        {
                            for (int j = 0; j < this.ScaleCutCount - 1; j++)
                            {
                                group_y += pixel / this.ScaleCutCount;
                                float group_x1 = scale_rect.Right;
                                float group_x2 = scale_rect.Right + this.lineExtent / 2;
                                if (this.scaleDirectionType == ScaleDirection.Right)
                                {
                                    group_x1 = scale_rect.X - this.lineExtent / 2;
                                    group_x2 = scale_rect.X;
                                }
                                g.DrawLine(scaleCutLine_pen, group_x1, group_y, group_x2, group_y);
                            }
                        }
                    }
                    #endregion

                    #region  刻度值
                    if (this.scaleTextShow)
                    {
                        SizeF str_size = g.MeasureString(str.ToString(), this.Font);
                        float text_x1 = line_x2;
                        if (this.scaleDirectionType == ScaleDirection.Right)
                        {
                            text_x1 = scale_rect.X - this.lineExtent - str_size.Width;
                        }
                        g.DrawString(str.ToString(), this.ScaleTextFont, scaleLineText_sb, text_x1, line_y - str_size.Height / 2);
                    }
                    #endregion

                }
                scaleLineText_sb.Dispose();
                scaleCutLine_pen.Dispose();
                scaleLine_pen.Dispose();
            }
            #endregion


        }

       /* protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/

        /// <summary>
        /// 刻度线显示位置
        /// </summary>
        [Description("刻度线显示位置")]
        public enum ScaleDirection
        {
            /// <summary>
            /// 左
            /// </summary>
            Left,
            /// <summary>
            /// 右
            /// </summary>
            Right
        }

        /// <summary>
        /// 温度计事件参数
        /// </summary>
        [Description("温度计事件参数")]
        public class TemperatureEventArgs : EventArgs
        {
            /// <summary>
            /// 温度值
            /// </summary>
            [Description("温度值")]
            public float Value { get; set; }
        }
    }
}
