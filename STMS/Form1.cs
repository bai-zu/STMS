using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace STMS
{
    public partial class Form1 : Form
    {
        AutoSizeFormClass autoSizeFormClass= new AutoSizeFormClass(416, 264);
        public Form1()
        {
            
            InitializeComponent();
            //AutoSizeFormClass autoSizeFormClass = new AutoSizeFormClass(Width, Height);
            autoSizeFormClass.setTag(this);
            //autoSizeFormClass(Width, Height);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否退出", "关闭", MessageBoxButtons.OKCancel) ==DialogResult.OK)
            {
                return;
            }
            else
            {

                e.Cancel = true;
            }
            
        }
        private void uCircleButton1_Click(object sender, EventArgs e)
        {
            if (uname.Text=="")
            {
                MessageBox.Show("账号不能为空");
            }
            else if(upwd.Text=="")
            {
                MessageBox.Show("密码不能为空");
            }
            else
            {
                string connstr = "server=127.0.0.1;database=test;username=root;password=2326;";
                //创建MySqlConnection对象
                using (MySqlConnection connection = new MySqlConnection(connstr))
                {
                    //string sql = "SELECT * FROM goods where id="+textBox1.Text+" and name="+textBox2.Text;
                    string sql = "SELECT id,name FROM goods";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        connection.Open();
                        MySqlDataReader mySqlDataReader = command.ExecuteReader();
                        bool a = false;
                        while (mySqlDataReader.Read())
                        {
                            if (mySqlDataReader["id"].ToString() == uname.Text && mySqlDataReader["name"].ToString() == upwd.Text)
                            {
                                a = true;
                                break;
                            }
                        }
                        if (a)
                        {
                            MessageBox.Show("登录成功");
                            logOn();
                        }
                        else
                        {
                            MessageBox.Show("登录失败");
                        }
                        
                    }
                }
            }
        }
        public void logOn (){
            logon logon = new logon();
            logon.Tag = uname.Text;
            //MessageBox.Show(logon.Tag.ToString());
            logon.Show();
            this.Hide();
        
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            /*AutoSizeForm form = new AutoSizeForm();
            form.controlAutoSize(this);*/
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            
            autoSizeFormClass.ReWinformLayout(Width, Height,this);
        }
    }
}
