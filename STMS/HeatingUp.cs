using STMS.UControls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace STMS
{
    public partial class HeatingUp : Form
    {
        public HeatingUp()
        {
            InitializeComponent();
        }

        private void HeatingUp_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            //list = this.Tag.ToString();
            //this.Tag = list;
            //MessageBox.Show(this.Tag.ToString());
            //string a = UStoreRegionBox.id;
            numericUpDown1.Value = int.Parse(UStoreRegionBox.temperature);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                numericUpDown1.Value = numericUpDown1.Value + 5;
            }
            else
            {
                numericUpDown1.Value = numericUpDown1.Value - 5;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                numericUpDown1.Value = numericUpDown1.Value + 7;
            }
            else
            {
                numericUpDown1.Value = numericUpDown1.Value - 7;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                numericUpDown1.Value = numericUpDown1.Value + 3;
            }
            else
            {
                numericUpDown1.Value = numericUpDown1.Value - 3;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int a = numericUpDown1.Value;
            string sql = "UPDATE productdetails SET temperature = "+ numericUpDown1.Value + " WHERE id='" + UStoreRegionBox.id+"'";
            //MessageBox.Show(sql);
            SqlExecute sqlExecute = new SqlExecute();
            if (sqlExecute.AddDeleteAndModify(sql)>0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }

        }
    }
}
