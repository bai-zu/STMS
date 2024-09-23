using MySql.Data.MySqlClient;
using STMS.UControls;
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
    public partial class Increase : Form
    {
        public Increase()
        {
            InitializeComponent();
        }

        private void uCircleButton1_Click(object sender, EventArgs e)
        {
            string sql = null;
            if (uCircleButton1.Text == "更新")
            {
                sql = "UPDATE province SET name ='"+textBox2.Text+ "',jiancheng ='"+textBox3.Text+ "',shenghui='"+textBox4.Text+"' WHERE id="+textBox1.Text+";";
                //MessageBox.Show(sql);
                SqlExecute sqlExecute = new SqlExecute();
                if (sqlExecute.AddDeleteAndModify(sql) > 0)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
            }
            else
            {
                sql = "INSERT INTO province(id,name,jiancheng,shenghui) VALUE('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                SqlExecute sqlExecute = new SqlExecute();
                if (sqlExecute.AddDeleteAndModify(sql) > 0)
                {
                    MessageBox.Show("添加成功");
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
            }
            this.Close();
        }

        private void Increase_Load(object sender, EventArgs e)
        {
            //List<string> list = (List<string>)this.Tag;
            if (this.Tag!=null)
            {
                List<string> list = (List<string>)this.Tag;
                textBox1.Text = list[0];
                textBox2.Text = list[1];
                textBox3.Text = list[2];
                textBox4.Text = list[3];
                uCircleButton1.Text = "更新";
                /*for (int i = 0; i < list.Count; i++)
                {
                    MessageBox.Show(list[i]);
                }*/
                //MessageBox.Show(this.Tag.ToString());
                //this.Tag
            }
        }
    }
}
