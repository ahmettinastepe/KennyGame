using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KennyGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        private int skor = 0;
        private int timer = 30;
        Random random = new Random();

        void HideKenny()
        {
            PictureBox[] kennyArray = { kenny1, kenny2, kenny3, kenny4, kenny5, kenny6, kenny7, kenny8, kenny9 };

            foreach (var kenny in kennyArray)
            {
                kenny.Visible = false;
            }

            var kennyShow = random.Next(0, kennyArray.Length);
            kennyArray[kennyShow].Visible = true;
        }

        void TimerDown()
        {
            timerBoard.Enabled = true;
            timerBoard.Start();
            timerKenny.Start();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TimerDown();
            HideKenny();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            skor += 1;
            lblSkor.Text = skor.ToString();
        }
        private void timerBoard_Tick(object sender, EventArgs e)
        {
            timer--;
            lblTimer.Text = timer.ToString();

            if (timer == 0)
            {
                timerBoard.Stop();
                timerKenny.Stop();
                DialogResult mesaj = MessageBox.Show("Zaman Doldu", "Zamanınız Doldu. Tekrar oynamak ister misiniz?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (mesaj == DialogResult.Yes)
                {
                    TimerDown();
                    HideKenny();
                    skor = 0;
                    timer = 31;
                }
            }
        }
        private void timerKenny_Tick(object sender, EventArgs e)
        {
            HideKenny();
        }
    }
}
