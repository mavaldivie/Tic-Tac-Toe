using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        Image exis = new Bitmap(Environment.CurrentDirectory + "\\..\\..\\Exis.png");
        Image oes = new Bitmap(Environment.CurrentDirectory + "\\..\\..\\Oes.png");
        Image empty = new Bitmap(Environment.CurrentDirectory + "\\..\\..\\Empty.png");

        bool blocked = false;
        TTTPlayer ia;
        PictureBox[,] pb = new PictureBox[3, 3];
        void restart(int turn=1)
        {
            blocked = false;
            textBox1.Text = "";
            ia = new TTTPlayer(new int[3, 3], turn);
            if(turn == 1) IAPlay();
            refresh();
        }

        public Form1()
        {
            InitializeComponent();
            pb[0, 0] = pictureBox1;
            pb[0, 1] = pictureBox2;
            pb[0, 2] = pictureBox3;
            pb[1, 0] = pictureBox4;
            pb[1, 1] = pictureBox5;
            pb[1, 2] = pictureBox6;
            pb[2, 0] = pictureBox7;
            pb[2, 1] = pictureBox8;
            pb[2, 2] = pictureBox9;
            restart();
        }

        void refresh()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (ia.arr[i, j] == -1)
                        pb[i, j].Image = oes;
                    else if (ia.arr[i, j] == 1)
                        pb[i, j].Image = exis;
                    else
                        pb[i, j].Image = empty;
                }
        }
        void IAPlay()
        {
            var status = ia.Status();
            if (status != State.NotFinished) return;
            
            ia.PlayComputer();
            refresh();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (blocked) return;
            if (!ia.PlayHuman(0, 0)) return;
            refresh();

            IAPlay();

            if (ia.Status() == State.Victory)
            {
                textBox1.Text = "You lost";
                blocked = true;
            }
            else if (ia.Status() == State.Draw)
            {
                textBox1.Text = "Draw";
                blocked = true;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (blocked) return;
            if (!ia.PlayHuman(0, 1)) return;
            refresh();

            IAPlay();

            if (ia.Status() == State.Victory)
            {
                textBox1.Text = "You lost";
                blocked = true;
            }
            else if (ia.Status() == State.Draw)
            {
                textBox1.Text = "Draw";
                blocked = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (blocked) return;
            if (!ia.PlayHuman(0, 2)) return;
            refresh();

            IAPlay();

            if (ia.Status() == State.Victory)
            {
                textBox1.Text = "You lost";
                blocked = true;
            }
            else if (ia.Status() == State.Draw)
            {
                textBox1.Text = "Draw";
                blocked = true;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (blocked) return;
            if (!ia.PlayHuman(1, 0)) return;
            refresh();

            IAPlay();

            if (ia.Status() == State.Victory)
            {
                textBox1.Text = "You lost";
                blocked = true;
            }
            else if (ia.Status() == State.Draw)
            {
                textBox1.Text = "Draw";
                blocked = true;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (blocked) return;
            if (!ia.PlayHuman(1, 1)) return;
            refresh();

            IAPlay();

            if (ia.Status() == State.Victory)
            {
                textBox1.Text = "You lost";
                blocked = true;
            }
            else if (ia.Status() == State.Draw)
            {
                textBox1.Text = "Draw";
                blocked = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (blocked) return;
            if (!ia.PlayHuman(1, 2)) return;
            refresh();

            IAPlay();

            if (ia.Status() == State.Victory)
            {
                textBox1.Text = "You lost";
                blocked = true;
            }
            else if (ia.Status() == State.Draw)
            {
                textBox1.Text = "Draw";
                blocked = true;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (blocked) return;
            if (!ia.PlayHuman(2, 0)) return;
            refresh();

            IAPlay();

            if (ia.Status() == State.Victory)
            {
                textBox1.Text = "You lost";
                blocked = true;
            }
            else if (ia.Status() == State.Draw)
            {
                textBox1.Text = "Draw";
                blocked = true;
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (blocked) return;
            if (!ia.PlayHuman(2, 1)) return;
            refresh();

            IAPlay();

            if (ia.Status() == State.Victory)
            {
                textBox1.Text = "You lost";
                blocked = true;
            }
            else if (ia.Status() == State.Draw)
            {
                textBox1.Text = "Draw";
                blocked = true;
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (blocked) return;
            if (!ia.PlayHuman(2, 2)) return;
            refresh();

            IAPlay();

            if (ia.Status() == State.Victory)
            {
                textBox1.Text = "You lost";
                blocked = true;
            }
            else if (ia.Status() == State.Draw)
            {
                textBox1.Text = "Draw";
                blocked = true;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            restart(-1);
        }
    }
}
