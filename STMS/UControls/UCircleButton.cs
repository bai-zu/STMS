﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STMS.UControls
{
    public partial class UCircleButton : Button
    {
        public enum ControlState { Hover, Normal, Pressed }
        private int radius;//半径 
        //private Color _borderColor = Color.FromArgb(51, 161, 224);//边框颜色
        private Color _hoverColor = Color.FromArgb(220, 80, 80);//基颜色
        private Color _normalColor = Color.FromArgb(51, 161, 224);//基颜色
        private Color _pressedColor = Color.FromArgb(251, 161, 0);//基颜色

        private ContentAlignment _textAlign = ContentAlignment.MiddleCenter;

        public override ContentAlignment TextAlign
        {
            set
            {
                _textAlign = value;
                this.Invalidate();
            }
            get
            {
                return _textAlign;
            }
        }

        /// <summary>
        /// 圆角按钮的半径属性
        /// </summary>
        [CategoryAttribute("Layout"), BrowsableAttribute(true), ReadOnlyAttribute(false)]
        public int Radius
        {
            set
            {
                radius = value;
                // 使控件的整个画面无效并重绘控件
                this.Invalidate();
            }
            get
            {
                return radius;
            }
        }
        [CategoryAttribute("Appearance"), DefaultValue(typeof(Color), "51, 161, 224")]
        public Color NormalColor
        {
            get
            {
                return this._normalColor;
            }
            set
            {
                this._normalColor = value;
                this.Invalidate();
            }
        }
        [CategoryAttribute("Appearance"), DefaultValue(typeof(Color), "220, 80, 80")]
        public Color HoverColor
        {
            get
            {
                return this._hoverColor;
            }
            set
            {
                this._hoverColor = value;
                this.Invalidate();
            }
        }

        [CategoryAttribute("Appearance"), DefaultValue(typeof(Color), "251, 161, 0")]
        public Color PressedColor
        {
            get
            {
                return this._pressedColor;
            }
            set
            {
                this._pressedColor = value;
                this.Invalidate();
            }
        }

        public ControlState controlState { get; set; }

        protected override void OnMouseEnter(EventArgs e)//鼠标进入时
        {
            controlState = ControlState.Hover;//Hover
            base.OnMouseEnter(e);
        }
        protected override void OnMouseLeave(EventArgs e)//鼠标离开
        {
            controlState = ControlState.Normal;//正常
            base.OnMouseLeave(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)//鼠标按下
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)//鼠标左键且点击次数为1
            {
                controlState = ControlState.Pressed;//按下的状态
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)//鼠标弹起
        {
            if (e.Button == MouseButtons.Left && e.Clicks == 1)
            {
                if (ClientRectangle.Contains(e.Location))//控件区域包含鼠标的位置
                {
                    controlState = ControlState.Hover;
                }
                else
                {
                    controlState = ControlState.Normal;
                }
            }
            base.OnMouseUp(e);
        }
        public UCircleButton()
        {
            ForeColor = Color.White;
            Radius = 20;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.controlState = ControlState.Normal;
            this.SetStyle(
             ControlStyles.UserPaint |  //控件自行绘制，而不使用操作系统的绘制
             ControlStyles.AllPaintingInWmPaint | //忽略背景擦除的Windows消息，减少闪烁，只有UserPaint设为true时才能使用。
             ControlStyles.OptimizedDoubleBuffer |//在缓冲区上绘制，不直接绘制到屏幕上，减少闪烁。
             ControlStyles.ResizeRedraw | //控件大小发生变化时，重绘。                  
             ControlStyles.SupportsTransparentBackColor, //支持透明背景颜色
             true);
        }


        //重写OnPaint
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            // base.OnPaintBackground(e);

            // 尽可能高质量绘制
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            var path = GetRoundedRectPath(rect, radius);

            this.Region = new Region(path);

            Color baseColor;
            //Color borderColor;
            //Color innerBorderColor = this._baseColor;//Color.FromArgb(200, 255, 255, 255); ;

            switch (controlState)
            {
                case ControlState.Hover:
                    baseColor = this._hoverColor;
                    break;
                case ControlState.Pressed:
                    baseColor = this._pressedColor;
                    break;
                case ControlState.Normal:
                    baseColor = this._normalColor;
                    break;
                default:
                    baseColor = this._normalColor;
                    break;
            }

            using (SolidBrush b = new SolidBrush(baseColor))
            {
                e.Graphics.FillPath(b, path); // 填充路径，而不是DrawPath
                using (Brush brush = new SolidBrush(this.ForeColor))
                {
                    // 文本布局对象
                    using (StringFormat gs = new StringFormat())
                    {
                        // 文字布局
                        switch (_textAlign)
                        {
                            case ContentAlignment.TopLeft:
                                gs.Alignment = StringAlignment.Near;
                                gs.LineAlignment = StringAlignment.Near;
                                break;
                            case ContentAlignment.TopCenter:
                                gs.Alignment = StringAlignment.Center;
                                gs.LineAlignment = StringAlignment.Near;
                                break;
                            case ContentAlignment.TopRight:
                                gs.Alignment = StringAlignment.Far;
                                gs.LineAlignment = StringAlignment.Near;
                                break;
                            case ContentAlignment.MiddleLeft:
                                gs.Alignment = StringAlignment.Near;
                                gs.LineAlignment = StringAlignment.Center;
                                break;
                            case ContentAlignment.MiddleCenter:
                                gs.Alignment = StringAlignment.Center; //居中
                                gs.LineAlignment = StringAlignment.Center;//垂直居中
                                break;
                            case ContentAlignment.MiddleRight:
                                gs.Alignment = StringAlignment.Far;
                                gs.LineAlignment = StringAlignment.Center;
                                break;
                            case ContentAlignment.BottomLeft:
                                gs.Alignment = StringAlignment.Near;
                                gs.LineAlignment = StringAlignment.Far;
                                break;
                            case ContentAlignment.BottomCenter:
                                gs.Alignment = StringAlignment.Center;
                                gs.LineAlignment = StringAlignment.Far;
                                break;
                            case ContentAlignment.BottomRight:
                                gs.Alignment = StringAlignment.Far;
                                gs.LineAlignment = StringAlignment.Far;
                                break;
                            default:
                                gs.Alignment = StringAlignment.Center; //居中
                                gs.LineAlignment = StringAlignment.Center;//垂直居中
                                break;
                        }
                        // if (this.RightToLeft== RightToLeft.Yes)
                        // {
                        //     gs.FormatFlags = StringFormatFlags.DirectionRightToLeft;
                        // }  
                        e.Graphics.DrawString(this.Text, this.Font, brush, rect, gs);
                    }
                }
            }
        }
        /// <summary>
        /// 根据矩形区域rect，计算呈现radius圆角的Graphics路径
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            #region 正确绘制圆角矩形区域
            int R = radius * 2;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(R, R));
            GraphicsPath path = new GraphicsPath();
            // 左上圆弧 左手坐标系，顺时针为正 从180开始，转90度
            path.AddArc(arcRect, 180, 90);
            // 右上圆弧
            arcRect.X = rect.Right - R;
            path.AddArc(arcRect, 270, 90);
            // 右下圆弧
            arcRect.Y = rect.Bottom - R;
            path.AddArc(arcRect, 0, 90);
            // 左下圆弧
            arcRect.X = rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
            #endregion
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }
    }
}
