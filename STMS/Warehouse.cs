using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STMS
{
    public partial class Warehouse : Form
    {
        string connstr = "server=127.0.0.1;database=test;username=root;password=2326;";
        public Warehouse()
        {
            InitializeComponent();
        }

        private void Warehouse_Shown(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string sql= "SELECT * FROM province";

            if (textBox1.Text != "")
            {
                sql = "SELECT * FROM province where name='" + textBox1.Text.ToString()+ "' or jiancheng='"+ textBox1.Text.ToString()+"'";
                //MessageBox.Show(sql);
            }
            else
            {
                sql = "SELECT * FROM province";
            }

            SqlExecute sqlExecute = new SqlExecute();
            MySqlDataReader mySqlDataReader= sqlExecute.Query(sql);

            while (mySqlDataReader.Read())
            {
                int i = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["id"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["name"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["jiancheng"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["shenghui"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Increase increase = new Increase();
            increase.Show();
            //MessageBox.Show("登录成功");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            string a = (string)dataGridView1.Rows[Index].Cells[1].Value;
            string sql = null;
            if (dataGridView1.Rows[Index].Cells[0].Value != this.dataGridView1.CurrentCell.Value)
            {
                if (Index < this.dataGridView1.Rows.Count - 1 && this.dataGridView1.CurrentCell.Value.ToString() == "删除")//"点击这里是之前设置按钮列的文本",
                {
                    //this.dataGridView1.CurrentCell.Value.ToString()== "点击这里";的用意是判断选中单元格是不是按钮单元格

                    //MessageBox.Show(a);
                    sql = "DELETE FROM province WHERE id =" + a;
                    SqlExecute sqlExecute = new SqlExecute();
                    if (sqlExecute.AddDeleteAndModify(sql) > 0)
                    {
                        MessageBox.Show("删除成功");
                        Warehouse_Shown(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("删除失败");
                    }
                }
                else
                {
                    sql = "SELECT * FROM province where id=" + a;
                    SqlExecute sqlExecute = new SqlExecute();
                    MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
                    Increase increase = new Increase();
                    List<string> list = new List<string>();
                    while (mySqlDataReader.Read())
                    {
                        list.Add(mySqlDataReader["id"].ToString());
                        list.Add(mySqlDataReader["name"].ToString());
                        list.Add(mySqlDataReader["jiancheng"].ToString());
                        list.Add(mySqlDataReader["shenghui"].ToString());
                    }
                    increase.Tag = list;
                    increase.Show();
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Warehouse_Shown(sender,e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("");
            logon logon = new logon();
            logon.button3_Click(sender,e);
        }
    }
}
