﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FGame
{
    public partial class Resume : Form
    {
        Form f;
        public Resume(Form f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f.Hide();
            StartPage s = new StartPage();
            this.Hide();
            s.Show();
        }
    }
}
