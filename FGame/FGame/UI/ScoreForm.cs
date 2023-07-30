using System;
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
    public partial class ScoreForm : Form
    {
        private int nScore;
        public ScoreForm(int score)
        {
            this.nScore = score;
            InitializeComponent();
            HandleLabels();
        }
        private void HandleLabels()
        {
            if (nScore >= 500)
            {
                winLose_lbl.Text = "Congratulations \U0001f973 ! You Won";
                score_lbl.Text = this.nScore.ToString();
            }
            else if (nScore < 500)
            {
                winLose_lbl.Text = "OOPS \U0001f97a ! You Lost";
                score_lbl.Text = this.nScore.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartPage s = new StartPage();
            this.Hide();
            s.Show();
        }
    }
}
