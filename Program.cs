using System;
using System.Threading;
using System.Windows.Forms;

namespace _4_Gewinnt
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    internal class Game
    {
        private bool[,] red_set;
        private bool[,] blue_set;
        private bool[,] gen_set;
        private bool red_turn;
        private PictureBox[,] red_list;
        private PictureBox[,] blue_list;
        private Label label_turn;
        private int counter_blue = 0;
        private int counter_red = 0;

        public Game(PictureBox[,] blue, PictureBox[,] red, Label label_turn)
        {
            this.blue_list = blue;
            this.red_list = red;
            this.red_turn = true;
            this.label_turn = label_turn;

            bool[,] red_set = new bool[7, 6]
            {
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
            };
            this.red_set = red_set;
            bool[,] blue_set = new bool[7, 6]
            {
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
            };
            this.blue_set = blue_set;
            bool[,] gen_set = new bool[7, 6]
            {
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
                {false, false, false, false, false, false},
            };
            this.gen_set = gen_set;
        }
        public void bt_callback(int row)
        // setzlogic
        {
            for (int i = 5; i > -1; i--) //für jedes horizontale teil
            {
                if (this.red_turn) //welcher spieler ist dran
                {
                    if (this.gen_set[row, i] == true) //wenn eines der teile in der reihe gesetzt ist
                    {
                        if (i < 5) //und es nicht das letzte ist, wegen index out of bounce
                        {
                            this.red_set[row, i + 1] = true; // setzt das rote Array auf aune pos über i
                            this.gen_set[row, i + 1] = true; // setzt das generelle Arry ganu so wie red
                            this.red_list[row, i + 1].Visible = true; // macht den Punkt sichtbar
                            this.red_turn = false; //beendet den zug
                            this.label_turn.Text = "waiting for player blue"; // ändert den text neben dem playfield
                            Check_finish();
                            return; //geht aus dem for loop raus damit nicht das event für blau getriggert wird
                        }
                        else
                        {
                            return; //wenn voll
                        }
                    }
                    else if (i == 0 && this.gen_set[row, i] == false) //wenn das das erste in der reihe ist und nichts anders da ist
                    {
                        this.red_set[row, i] = true;
                        this.gen_set[row, i] = true;
                        this.red_list[row, i].Visible = true;
                        this.red_turn = false;
                        this.label_turn.Text = "waiting for player blue";
                        Check_finish();
                        return;
                    }
                }
                else if (red_turn == false) // ab hier copy & paste für blau
                {
                    if (this.gen_set[row, i] == true)
                    {
                        if (i < 5)
                        {
                            this.blue_set[row, i + 1] = true;
                            this.gen_set[row, i + 1] = true;
                            this.blue_list[row, i + 1].Visible = true;
                            this.red_turn = true;
                            this.label_turn.Text = "waiting for player red";
                            Check_finish();
                            return;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else if (i == 0 && this.gen_set[row, i] == false)
                    {
                        this.blue_set[row, i] = true;
                        this.gen_set[row, i] = true;
                        this.blue_list[row, i].Visible = true;
                        this.label_turn.Text = "waiting for player red";
                        this.red_turn = true;
                        Check_finish();
                    }
                }
            }
        }
        public void Check_finish()
        {
            int debug_counter = 0;
            for (int i = 0; i < 7; i++) //spalte // vertical checker
            {
                debug_counter++;
                for (int j = 0; j < 6; j++) //horizontale
                {
                    if (this.red_set[i, j]) // wenn eine rotes gesetzt ist
                    {
                        this.counter_red++;
                        if (this.counter_red == 4)
                        {
                            this.label_turn.Text = "Player red won";
                            Reset();
                            return;
                        }
                    }
                    else
                    {
                        this.counter_red = 0;
                    }
                    if (this.blue_set[i, j]) // wenn eine blaues gesetzt ist
                    {
                        this.counter_blue++;
                        if (this.counter_blue == 4)
                        {
                            this.label_turn.Text = "Player blue won";
                            Reset();
                            return;
                        }
                    }
                    else
                    {
                        this.counter_blue = 0;
                    }
                }
                this.counter_red = 0;
                this.counter_blue = 0;

            }
            // 
            for (int j = 0; j < 6; ++j)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (this.red_set[i, j])
                    {
                        this.counter_red++;
                        if (this.counter_red == 4)
                        {
                            this.label_turn.Text = "Player red won";
                            Reset();
                            return;
                        }
                    }
                    else
                    {
                        this.counter_red = 0;
                    }
                    if (this.blue_set[i, j])
                    {
                        this.counter_blue++;
                        if (this.counter_blue == 4)
                        {
                            this.label_turn.Text = "Player blue won";
                            Reset();
                            return;
                        }
                    }
                    else
                    {
                        this.counter_blue = 0;
                    }
                }
                this.counter_red = 0;
                this.counter_blue = 0;
            }
            ///für jedes teil das schräd darüber abrufen, dann speicher und das nächste wenn keines da ist ne index out of bounce exeption nehmen und einfach zum eig nächsten teil weiter gehen und nur für untere 4x3 feld
            for (int column = 0; column < 3; column++)
            {
                for (int row = 0; row < 4; row++)
                {
                    if (this.red_set[row, column])
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (this.red_set[i + row, i + column])
                            {
                                this.counter_red++;
                                if (this.counter_red == 4)
                                {
                                    this.label_turn.Text = "Player red won";
                                    Reset();
                                    return;
                                }
                            }
                            else
                            {
                                this.counter_red = 0;
                            }
                        }
                        this.counter_red = 0;
                    }
                    else if (this.blue_set[column, row])
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (this.blue_set[i + row, i + column])
                            {
                                this.counter_blue++;
                                if (this.counter_blue == 4)
                                {
                                    this.label_turn.Text = "Player blue won";
                                    Reset();
                                    return;
                                }
                            }
                            else { this.counter_blue = 0; }
                        }
                        this.counter_blue = 0;
                    }
                }
            }
            ///
            for (int column = 5; column > 2; column--)
            {
                for (int row = 0; row < 4; row++)
                {
                    if (this.red_set[row, column])
                    {
                        for (int i = 0; i > -4; i--)
                        {
                            if (this.red_set[i * -1 + row, i + column])
                            {
                                this.counter_red++;
                                if (this.counter_red == 4)
                                {
                                    this.label_turn.Text = "Player red won";
                                    Reset();
                                    return;
                                }
                            }
                        }
                    }
                    else if (this.blue_set[row, column])
                    {
                        for (int i = 0; i > -4; i--)
                        {
                            if (this.blue_set[i * -1 + row, i + column])
                            {
                                this.counter_blue++;
                                if (this.counter_blue == 4)
                                {
                                    this.label_turn.Text = "Player blue won";
                                    Reset();
                                    return;
                                }
                            }
                            else { this.counter_blue = 0; }
                        }
                    }
                    this.counter_blue = 0;
                    this.counter_red = 0;
                }
            }

        }
        internal void Reset(bool fr_bt = false)
        {
            this.counter_red = 0;
            this.counter_blue = 0;
            foreach (PictureBox picure in this.red_list)
            {
                picure.Visible = false;
            }
            foreach (PictureBox pictue in this.blue_list)
            {
                pictue.Visible = false;
            }
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    red_set[i, j] = false;
                    blue_set[i, j] = false;
                    gen_set[i, j] = false;
                }
            }
            red_turn = true;
            Thread.Sleep(50);
            if (fr_bt) { this.label_turn.Text = "waiting for player red"; }
            else { this.label_turn.Text += " next red"; }

        }

    }
}
