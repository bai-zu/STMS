﻿using System;
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
    public partial class Temperature : Form
    {
        public Temperature()
        {
            InitializeComponent();
        }

        private void Temperature_Load(object sender, EventArgs e)
        {
            //this.refresh();
            this.Invalidate();
        }

        private void uCircleButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("点击了");
            //this.refresh();
            this.Invalidate();
        }
    }
}
