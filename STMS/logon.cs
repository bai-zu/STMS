using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STMS
{
    public partial class logon : Form
    {
        AutoSizeFormClass autoSizeFormClass = new AutoSizeFormClass(568, 389);
        
        public logon()
        {
            InitializeComponent();
            MessageBox.Show(Width.ToString());
            MessageBox.Show(Height.ToString());
            autoSizeFormClass.setTag(this);
        }
        //仓库管理
        private void button1_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            //label6.Text = "仓库管理";
            Warehouse warehouse = new Warehouse();
            //嵌入的基本步骤
            warehouse.TopLevel = false;//将子窗体设置成非顶级控件
            warehouse.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            warehouse.Parent = panel5;//指定子窗体显示的容器
            warehouse.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            warehouse.Show();
            button2.ForeColor = Color.Red;
            button4.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
        }
        //产品管理
        private void button4_Click(object sender, EventArgs e)
        {
            button6_Click(sender,e);
            
        }
        //仓库管理页面
        private void button2_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }

        public void button3_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            //MessageBox.Show("这里？");
            //label6.Text = "仓库管理";
            //Warehouse warehouse = new Warehouse();
            Partition partition = new Partition();
            //嵌入的基本步骤
            partition.TopLevel = false;//将子窗体设置成非顶级控件
            partition.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            partition.Parent = panel5;//指定子窗体显示的容器
            partition.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            partition.Show();
            button3.ForeColor = Color.Red;
            button2.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
        }
        //仓库温控
        private void button5_Click(object sender, EventArgs e)
        {
            button7_Click(sender,e);
            
        }
        private void logon_FormClosing(object sender, FormClosingEventArgs e)
        {
            //会直接调用主窗口中的关闭事件
            Application.Exit();
        }
        //页面加载事件
        private void logon_Load(object sender, EventArgs e)
        {
           

            label4.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label3.Text = this.Tag.ToString();
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            //this.button1.BackColor = Color.Cyan;
        }

        private void button6_Enter(object sender, EventArgs e)
        {
            //this.button6.BackColor = Color.Cyan;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            this.button1.BackColor = Color.Cyan;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            this.button6.BackColor = Color.Cyan;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            this.button6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            this.button7.BackColor = Color.Cyan;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            this.button7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        }
        //产品管理
        private void button6_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            Product product = new Product();
            //嵌入的基本步骤
            product.TopLevel = false;//将子窗体设置成非顶级控件
            product.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            product.Parent = panel5;//指定子窗体显示的容器
            product.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            product.Show();
            button4.ForeColor = Color.Red;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button5.ForeColor = Color.Black;
        }
        //仓库温控管理
        private void button7_Click(object sender, EventArgs e)
        {
            panel5.Controls.Clear();
            Temperature temperature = new Temperature();
            //嵌入的基本步骤
            temperature.TopLevel = false;//将子窗体设置成非顶级控件
            temperature.FormBorderStyle = FormBorderStyle.None;//去掉子窗体边框
            temperature.Parent = panel5;//指定子窗体显示的容器
            temperature.Dock = DockStyle.Fill;//设置子窗体随容器大小自动调整
            temperature.Show();
            button5.ForeColor = Color.Red;
            button2.ForeColor = Color.Black;
            button3.ForeColor = Color.Black;
            button4.ForeColor = Color.Black;
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            //asc.controlAutoSize(this);
        }


        private void panel1_Resize(object sender, EventArgs e)
        {
            autoSizeFormClass.ReWinformLayout(Width, Height, this);
        }
    }
}
