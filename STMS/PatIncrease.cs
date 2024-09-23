using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace STMS
{
    public partial class PatIncrease : Form
    {
        public PatIncrease()
        {
            InitializeComponent();
        }

        private void uCircleButton1_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (textBox1.Text!=""&&textBox2.Text!=""&&textBox3.Text!="")
            {
                Random random = new Random();
                int figure = random.Next(100, 1000);
                sql = "INSERT INTO dish(id,name,category_id,price,code,image,description,status,sort,create_time,update_time,create_user,update_user,is_deleted)" +
                    " VALUE("+figure+",'"+textBox1.Text+ "',1413384954989060097,"+textBox2.Text+",12,'zz',"+textBox3.Text+ ",1,0,'2024-03-10 19:47:13','2024-03-10 19:47:17',1,1,0)";
                SqlExecute sqlExecute = new SqlExecute();
                if (sqlExecute.AddDeleteAndModify(sql)>0)
                {
                    MessageBox.Show("添加成功");
                    this.Close();

                }
                else
                {
                    MessageBox.Show("失败成功");
                }

            }
            else
            {
                MessageBox.Show("请把信息补充完整");
            }


        }
    }
}
