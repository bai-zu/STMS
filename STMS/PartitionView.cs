using MySql.Data.MySqlClient;
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
    public partial class PartitionView : Form
    {
        public PartitionView()
        {
            InitializeComponent();
        }

        private void PartitionView_Load(object sender, EventArgs e)
        {
            MySqlDataReader mySqlDataReade =(MySqlDataReader)this.Tag;
            if (mySqlDataReade != null)
            {
                while (mySqlDataReade.Read())
                {
                    //MessageBox.Show(mySqlDataReade["id"].ToString());
                    label7.Text = mySqlDataReade["id"].ToString();
                    label8.Text = mySqlDataReade["create_time"].ToString();
                    //MessageBox.Show(mySqlDataReade["is_deleted"].ToString());
                    if (mySqlDataReade["is_deleted"].ToString()=="0")
                    {
                        label9.Text = "售卖中";
                    }
                    else
                    {
                        label9.Text = "已下架";
                    }
                    textBox1.Text= mySqlDataReade["price"].ToString();
                    textBox2.Text= mySqlDataReade["description"].ToString();
                    textBox3.Text = mySqlDataReade["code"].ToString();
                    //label9.Text = mySqlDataReade["create_time"].ToString();
                }
            } 
        }

        private void uCircleButton1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE dish SET price ="+textBox1.Text+ ",description='"+textBox2.Text+ "',code='"+textBox3.Text+"' WHERE id='" + label7.Text + "'";
            //MessageBox.Show(sql);
            SqlExecute sqlExecute = new SqlExecute();
            int i= sqlExecute.AddDeleteAndModify(sql);
            if (i>0)
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }

        }
    }
}
