using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STMS
{
    public partial class Partition : Form
    {
        public Partition()
        {
            InitializeComponent();
        }

        private void Partition_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            comboBox1.Items.Clear();
            string sql = "";
           /* if (comboBox1.Text != "" || textBox1.Text != "")
            {
                if (checkBox1.Checked)
                {
                    sql = "SELECT * FROM category where name='" + comboBox1.Text + "' and is_deleted = 1";
                }
                else
                {
                    sql = "SELECT * FROM category where name='" + comboBox1.Text + "' and is_deleted = 0";
                }

            }
            else*/ if (checkBox1.Checked)
            {
                sql = "SELECT * FROM dish where is_deleted = 1";
                //sql = "SELECT * FROM dish where name='" + textBox1.Text.ToString() + "' or jiancheng='" + textBox1.Text.ToString() + "'";
                //MessageBox.Show(sql);
            }
            else
            {
                sql = "SELECT * FROM dish where is_deleted = 0";
            }

            SqlExecute sqlExecute = new SqlExecute();
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);

            while (mySqlDataReader.Read())
            {
                int i = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["id"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["name"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["price"].ToString();
                dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["description"].ToString();
                if (checkBox1.Checked)
                {
                    //dataGridView1.Rows[i].Cells[5].Value = "恢复";
                    //dataGridView1.CurrentCell.Value = "恢复";
                    dataGridView1.Rows[i].Cells[5].Value = "恢复";

                }
                else
                {
                    dataGridView1.Rows[i].Cells[5].Value = "删除";
                }
            }
            
            sql = "SELECT * FROM category";
            mySqlDataReader = sqlExecute.Query(sql);
            
            while (mySqlDataReader.Read())
            {
                comboBox1.Items.Add(mySqlDataReader["name"].ToString());
                
            }
            //mySqlDataReader.Close();
            sqlExecute.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connstr = "server=127.0.0.1;database=test;username=root;password=2326;";
            //string sql = "SELECT * FROM dish";
            //SqlExecute sqlExecute = new SqlExecute();
            int a = 0;
            string id = "";
            if (comboBox1.Text == ""&&textBox1.Text=="")
            {
                MessageBox.Show("为空");
            }
            else
            {
                //string sql = "SELECT * FROM category where name='"+ comboBox1.Text+"'";
                //string sql = "SELECT * FROM category where name = \"川菜\"";
                if (comboBox1.Text== "湘菜")
                {
                    a = 1;
                }
                else if (comboBox1.Text == "川菜")
                {
                    a = 2;
                }
                else if (comboBox1.Text == "粤菜")
                {
                    a = 3;
                }
                else if (comboBox1.Text == "饮品")
                {
                    a = 11;
                }
                else if (comboBox1.Text == "商务套餐")
                {
                    a = 5;
                }
                else if (comboBox1.Text == "主食")
                {
                    a = 12;
                }
                else if (comboBox1.Text == "儿童套餐")
                {
                    a = 6;
                }

                string sql = "SELECT * FROM category where sort="+a;
                //string hh = "湘菜";
                //string sql = "SELECT * FROM category where name like '%川%'";
                //string sql = "SELECT * FROM category where sort= 1";
                //MessageBox.Show(comboBox1.Text);
                MySqlDataReader mySqlDataReader;
                using (MySqlConnection connection = new MySqlConnection(connstr))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        mySqlDataReader = command.ExecuteReader();
                        while (mySqlDataReader.Read())
                        {
                            id = mySqlDataReader["id"].ToString();
                            //MessageBox.Show(mySqlDataReader["id"].ToString());
                        }
                    }
                    
                }
                sql = "SELECT * FROM dish where category_id=" + id;
                SqlExecute sqlExecute = new SqlExecute();
                mySqlDataReader = sqlExecute.Query(sql);
                dataGridView1.Rows.Clear();
                while (mySqlDataReader.Read())
                {
                    //dataGridView1.Rows.Clear();
                    int i = this.dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["id"].ToString();
                    dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["name"].ToString();
                    dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["price"].ToString();
                    dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["description"].ToString();
                    if (checkBox1.Checked)
                    {
                        //dataGridView1.Rows[i].Cells[5].Value = "恢复";
                        //dataGridView1.CurrentCell.Value = "恢复";
                        dataGridView1.Rows[i].Cells[5].Value = "恢复";

                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[5].Value = "删除";
                    }
                    //MessageBox.Show(mySqlDataReader["name"].ToString());

                }
                //MessageBox.Show(sql);
                //MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
                //string id = mySqlDataReader["name"].ToString();
                //mySqlDataReader.Read();
                //string id = mySqlDataReader.GetValue(0).ToString();
                /* while (mySqlDataReader.Read())
                 {
                     int i = this.dataGridView1.Rows.Add();
                     //id = mySqlDataReader["id"].ToString();
                     MessageBox.Show("这里？");

                 }
                 Partition_Load(sender,e);*/
                //MessageBox.Show(id);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int Index = this.dataGridView1.CurrentRow.Index;//获取当前选中行的索引
            string a = (string)dataGridView1.Rows[Index].Cells[1].Value;
            string sql = null;
            SqlExecute sqlExecute = new SqlExecute();
            if (Index < this.dataGridView1.Rows.Count - 1 )//"点击这里是之前设置按钮列的文本",
            {
                if (dataGridView1.Rows[Index].Cells[0].Value!= this.dataGridView1.CurrentCell.Value)
                {
                    //MessageBox.Show("点击了");
                    if (this.dataGridView1.CurrentCell.Value.ToString() == "删除")
                    {
                        sql = "UPDATE dish SET is_deleted = 1 WHERE id='" + a + "'";
                    }
                    else if (this.dataGridView1.CurrentCell.Value.ToString() == "恢复")
                    {
                        sql = "UPDATE dish SET is_deleted = 0 WHERE id='" + a + "'";
                    }
                    else
                    {
                        sql = "SELECT * FROM dish where id='" + a + "'";
                        MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
                        PartitionView partitionView = new PartitionView();
                        partitionView.Tag = mySqlDataReader;
                        partitionView.Show();
                        return;
                    }
                    if (sqlExecute.AddDeleteAndModify(sql) > 0)
                    {
                        MessageBox.Show("操作成功");
                        Partition_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                    }
                
                }
                
                
                
            }
            else
            {
                /*sql = "SELECT * FROM province where id=" + a;
                sqlExecute = new SqlExecute();
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
                increase.Show();*/
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PatIncrease patIncrease = new PatIncrease();
            patIncrease.Show();
             
        }

        private void uCircleButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("刷新成功");
            Partition_Load(sender,e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Partition_Load(sender,e);
        }
    }
}
