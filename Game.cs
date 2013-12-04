﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SelfBalancedTree;

namespace LightningBugs
{
    public partial class Game : UserControl
    {

        private static Player human;
        private static computerPlayer computer;

        public bool gameOver = false;
        private bool vComputer;
        public bool gamePaused;

        private AVLTree<GameImage> trails;

        public Game(bool option, int level = 1)
        {
            human = new Player(Resource1.carRed);
            computer = new computerPlayer(Resource1.carBlue);
            Controls.Add(human);
            Controls.Add(computer);
            InitializeComponent();
            computer.turn(Direction.down);
            vComputer = option;
            gamePaused = true; //default to paused

            trails = SingletonTrailTree.getInstance();
            
            moveTimer.Interval = 100;
            switch (level)
            {
                case (0):
                    moveTimer.Interval -= 40;
                    break;
                case (1):
                    moveTimer.Interval -= 60;
                    break;
                case (2):
                    moveTimer.Interval -= 90;
                    break;
                default:
                    break;
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            computer.Left = human.Left = ClientRectangle.Width / 2 - human.Width / 2;
            computer.Top = (int)computer.Width * 2;
            //computer.Top = 970;
            human.Top = ClientRectangle.Height - human.Height - (int)human.Width * 2;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (gamePaused)//game starts paused, this will move from a pause to start on any key
            {
                PauseGameEvent(new KeyPressEventArgs(keyData.ToString()[0]));
            }
            else if (keyData == Keys.Enter || keyData == Keys.P || keyData == Keys.Space) // toggle the pause while running on p or spacebar or return
            {
                PauseGameEvent(new KeyPressEventArgs(keyData.ToString()[0]));
            }
            

            if (!gameOver && !gamePaused)
            {

                //when game loads, timer is not enabled, this will enable it on first key press making game start on any key.


                Direction human0 = human.direction.getDirection();
                if (keyData == Keys.Up)
                {
                    human.turn(Direction.up);
                }
                else if (keyData == Keys.Down)
                {
                    human.turn(Direction.down);
                }
                else if (keyData == Keys.Left)
                {
                    human.turn(Direction.left);
                }
                else if (keyData == Keys.Right)
                {
                    human.turn(Direction.right);
                }


                Direction computer0 = computer.direction.getDirection();
                if (!vComputer)
                {

                    if (keyData == Keys.W)
                    {
                        computer.turn(Direction.up);
                    }
                    else if (keyData == Keys.S)
                    {
                        computer.turn(Direction.down);
                    }
                    else if (keyData == Keys.A)
                    {
                        computer.turn(Direction.left);
                    }
                    else if (keyData == Keys.D)
                    {
                        computer.turn(Direction.right);
                    }
                    if (human.direction.getDirection() != human0 || computer.direction.getDirection() != computer0 && !gameOver)
                    {
                        switch (checkForDeath())
                        {
                            case (1): moveTimer.Enabled = false; gameOver = true; MessageBox.Show("Blue WON!"); break;
                            case (2): moveTimer.Enabled = false; gameOver = true; MessageBox.Show("Red WON!"); break;
                        }

                    }

                }
                else if (human.direction.getDirection() != human0 || computer.direction.getDirection() != computer0 && !gameOver)
                {
                    switch (checkForDeath())
                    {
                        case (1): moveTimer.Enabled = false; gameOver = true; MessageBox.Show("You lost"); break;
                        case (2): moveTimer.Enabled = false; gameOver = true; MessageBox.Show("You WIN"); break;
                    }

                }
                else
                {

                }
            }

            return true;
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            if (!gameOver && !gamePaused)
            {


                GameImage humanTrail = new GameImage(Resource1.trailRed);
                human.move(humanTrail);
                Controls.Add(humanTrail);
                trails.Add(humanTrail);

                //if (!gameOver)
                //{
                //    switch (checkForDeath())
                //    {
                //        case (1): moveTimer.Enabled = false; gameOver = true; MessageBox.Show("You lost"); break;
                //        case (2): moveTimer.Enabled = false; gameOver = true; MessageBox.Show("You WIN"); break;
                //    }
                //}

                GameImage computerTrail = new GameImage(Resource1.trailBlue);

                if (vComputer)
                {
                    computer.turn(Controls);
                }
                computer.move(computerTrail);
                Controls.Add(computerTrail);
                trails.Add(computerTrail);

                if (!gameOver)
                {
                    if (!vComputer)
                    {
                        switch (checkForDeath())
                        {
                            case (1): moveTimer.Enabled = false; gameOver = true; MessageBox.Show("Blue WON!"); break;
                            case (2): moveTimer.Enabled = false; gameOver = true; MessageBox.Show("Red WON!"); break;
                        }
                    }
                    else
                    {
                        switch (checkForDeath())
                        {
                            case (1): moveTimer.Enabled = false; gameOver = true; MessageBox.Show("You lost"); break;
                            case (2): moveTimer.Enabled = false; gameOver = true; MessageBox.Show("You WIN"); break;
                        }
                    }
                }
            }
        }

        private int checkForDeath()
        {
            int result = 0;

            //foreach (GameImage image in Controls)
            //{

            //    KeyValuePair<int, int> pos = human.getFrontPosition();
            //    KeyValuePair<int, int> piecePos = image.centerPos();

            //    if (image != human && human.overlap(image) || (human.Top < -20 || human.Left < -20 || human.Bottom >= this.Height + 20 || human.Right >= this.Width + 20))
            //    {
            //        result = 1;
            //    }

            //    pos = computer.getFrontPosition();

            //    if (image != computer && computer.overlap(image) || (computer.Top < -20 || computer.Left < -20 || computer.Bottom > this.Height + 20 || computer.Right > this.Width + 20))
            //    {
            //        result = 2;
            //    }
            //}



            if (trails.Contains(human) || human.overlap(computer))
            {
                result = 1;
            }
            else if (trails.Contains(computer))
            {
                result = 2;
            }
            return result;
        }

        //section for raising the event
        //private bool pause;
        public bool Pause
        {
            get { return this.gamePaused; }
            set { this.gamePaused = value; }
        }

        public event EventHandler PauseGameEventHandlerVariable;

        public void pauseGame(object sender, EventArgs e = null)
        {
            //PauseGameEvent(e);
            gamePaused = !gamePaused;
            
            if (gamePaused == true)
            {
                moveTimer.Enabled = false;

            }
            else
            {
                moveTimer.Enabled = true;
                
            }

        }

        //private void btnStart_MouseLeave(object sender, EventArgs e)
        //{
        //    gamePaused = false;
        //}

        public delegate void PauseGameEventHandler(object sender, EventArgs e);

        public void PauseGameEvent(EventArgs e)
        {
            EventHandler handler = PauseGameEventHandlerVariable;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
