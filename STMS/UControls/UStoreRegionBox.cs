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

namespace STMS.UControls
{
    public partial class UStoreRegionBox : UserControl
    {
        public static string id="";
        public static string temperature = "";
        public UStoreRegionBox()
        {
            InitializeComponent();
        }

        private void uCircleButton1_Click(object sender, EventArgs e)
        {
            HeatingUp heatingUp = new HeatingUp();
            /* List<string> list = new List<string>();
             list.Add(this.label8.Text);
             list.Add(this.Tag.ToString());*/
            //heatingUp.Tag = list;
            temperature = this.label8.Text;
            heatingUp.Show();
            //MessageBox.Show("点击了");
        }

        private void UStoreRegionBox_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM productdetails";
            SqlExecute sqlExecute = new SqlExecute();
            MySqlDataReader mySqlDataReader = sqlExecute.Query(sql);
            while (mySqlDataReader.Read())
            {
                id = mySqlDataReader["id"].ToString();
                label7.Text = mySqlDataReader["number"].ToString();
                label8.Text = mySqlDataReader["temperature"].ToString();
                label9.Text = mySqlDataReader["max"].ToString()+"-"+ mySqlDataReader["min"].ToString();
            }
            if (int.Parse(label8.Text)> int.Parse(mySqlDataReader["max"].ToString()))
            {
                led1.CentorColor = Color.Red;
            }
            else if(int.Parse(label8.Text) < int.Parse(mySqlDataReader["min"].ToString()))
            {
                led1.CentorColor = Color.LawnGreen;
            }
            else
            {
                led1.CentorColor = Color.Aqua;
            }
            thermometer1.Value=int.Parse(label8.Text);
        }
    }
}
