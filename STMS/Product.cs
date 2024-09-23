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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dataGridView1.Rows.Clear();
            dataGridView1.Columns["number"].HeaderText = "添加时间";
            Product_Load(sender,e);
        }

        private void Product_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            //dataGridView1.Rows[0].HeaderCell = "";
            //dataGridView1.Columns["name"].HeaderText = "22";
            string sql = "SELECT * FROM dish_flavor";
            SqlExecute sqlExecute = new SqlExecute();
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                int i = this.dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = mySqlDataReader["id"].ToString();
                dataGridView1.Rows[i].Cells[1].Value = mySqlDataReader["name"].ToString();
                dataGridView1.Rows[i].Cells[2].Value = mySqlDataReader["value"].ToString();
                dataGridView1.Rows[i].Cells[3].Value = mySqlDataReader["create_time"].ToString();
                if (dataGridView1.Columns["number"].HeaderText== "添加时间")
                {
                    dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["update_time"].ToString();
                }
                else
                {
                    //MessageBox.Show(dataGridView1.Columns["name"].HeaderText);
                    dataGridView1.Rows[i].Cells[4].Value = mySqlDataReader["create_user"].ToString();
                }
                ;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns["number"].HeaderText = "库存数量";
            Product_Load(sender,e);
        }
    }
}
