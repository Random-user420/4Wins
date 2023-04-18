using System;
using System.Windows.Forms;

namespace _4_Gewinnt
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            PictureBox[,] blue_list = new PictureBox[7, 6]
            {
            {blue_0_0, blue_0_1, blue_0_2, blue_0_3, blue_0_4, blue_0_5},
            {blue_1_0, blue_1_1, blue_1_2, blue_1_3, blue_1_4, blue_1_5},
            {blue_2_0, blue_2_1, blue_2_2, blue_2_3, blue_2_4, blue_2_5},
            {blue_3_0, blue_3_1, blue_3_2, blue_3_3, blue_3_4, blue_3_5},
            {blue_4_0, blue_4_1, blue_4_2, blue_4_3, blue_4_4, blue_4_5},
            {blue_5_0, blue_5_1, blue_5_2, blue_5_3, blue_5_4, blue_5_5},
            {blue_6_0, blue_6_1, blue_6_2, blue_6_3, blue_6_4, blue_6_5}
            };
            foreach (var i in blue_list)
            {
                i.Parent = Background;
            }
            PictureBox[,] red_list = new PictureBox[7, 6]
            {
            {red_0_0, red_0_1, red_0_2, red_0_3, red_0_4, red_0_5},
            {red_1_0, red_1_1, red_1_2, red_1_3, red_1_4, red_1_5},
            {red_2_0, red_2_1, red_2_2, red_2_3, red_2_4, red_2_5},
            {red_3_0, red_3_1, red_3_2, red_3_3, red_3_4, red_3_5},
            {red_4_0, red_4_1, red_4_2, red_4_3, red_4_4, red_4_5},
            {red_5_0, red_5_1, red_5_2, red_5_3, red_5_4, red_5_5},
            {red_6_0, red_6_1, red_6_2, red_6_3, red_6_4, red_6_5}
            };
            foreach (var i in red_list)
            {
                i.Parent = Background;
            }
            Game Game1 = new Game(blue_list, red_list, label1);
            this.game = Game1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void blue_1_1_Click(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void reihe1_button_Click(object sender, EventArgs e)
        {
            this.game.bt_callback(0);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void blue_6_0_Click(object sender, EventArgs e)
        {

        }

        private void blue_1_5_Click(object sender, EventArgs e)
        {

        }

        private void blue_2_5_Click(object sender, EventArgs e)
        {

        }

        private void blue_3_5_Click(object sender, EventArgs e)
        {

        }

        private void blue_5_5_Click(object sender, EventArgs e)
        {

        }

        private void blue_6_4_Click(object sender, EventArgs e)
        {

        }

        private void blue_6_3_Click(object sender, EventArgs e)
        {

        }

        private void blue_6_2_Click(object sender, EventArgs e)
        {

        }

        private void blue_6_1_Click(object sender, EventArgs e)
        {

        }

        private void blue_5_0_Click(object sender, EventArgs e)
        {

        }

        private void blue_5_1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {

        }

        private void reihe2_button_Click(object sender, EventArgs e)
        {
            this.game.bt_callback(1);
        }

        private void reihe3_button_Click(object sender, EventArgs e)
        {
            this.game.bt_callback(2);
        }

        private void reihe4_button_Click(object sender, EventArgs e)
        {
            this.game.bt_callback(3);
        }

        private void reihe5_button_Click(object sender, EventArgs e)
        {
            this.game.bt_callback(4);
        }

        private void reihe6_button_Click(object sender, EventArgs e)
        {
            this.game.bt_callback(5);
        }

        private void reihe7_button_Click(object sender, EventArgs e)
        {
            this.game.bt_callback(6);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            this.game.Reset(true);
        }
    }

}
