using System;
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

        private   Player human;
        private   computerPlayer computer;

        public bool gameOver = false;
        private bool vComputer;
        private bool gamePaused;
        private bool gameStarted;

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
            gameStarted = false;
            trails = SingletonTrailTree.getInstance(true);
            lblMessage.Visible = false;
            RedLived = true;
            BlueLived = true;
            gameOver = false;
            Tie = false;
            

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
            human.Top = ClientRectangle.Height - human.Height - (int)human.Width * 2;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (gamePaused && !gameOver)//game starts paused, this will move from a pause to start on any key
            {
                PauseGameEvent(new KeyPressEventArgs(keyData.ToString()[0]));
            }
            else if ((keyData == Keys.Enter || keyData == Keys.P || keyData == Keys.Space)&& !gameOver) // toggle the pause while running on p or spacebar or return
            {
                PauseGameEvent(new KeyPressEventArgs(keyData.ToString()[0]));
            }

            if (!gameOver && !gamePaused)
            {

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
                        checkForDeath();
                    }
                }
                else if (human.direction.getDirection() != human0 || computer.direction.getDirection() != computer0 && !gameOver)
                {
                    checkForDeath();
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

                GameImage computerTrail = new GameImage(Resource1.trailBlue);

                if (vComputer)
                {
                    computer.turn(Controls);
                }
                computer.move(computerTrail);
                Controls.Add(computerTrail);
                trails.Add(computerTrail);

                checkForDeath();
            }
        }

        private bool RedLived;
        private bool BlueLived;
        private bool Tie;

        private void checkForDeath()
        {
            bool gameOver = false;
            RedLived = true;
            BlueLived = true;
            if (trails.Contains(human) || human.overlap(computer) || human.Left < 0 || human.Right > this.Width || human.Top < 0 || human.Bottom > this.Height)
            {
                RedLived = false;
                gameOver = true;
            }
            if (trails.Contains(computer) || computer.Left < 0 || computer.Right > this.Width || computer.Top < 0 || computer.Bottom > this.Height)
            {
                BlueLived = false;
                gameOver = true;
            }

            if (!vComputer && (human.overlap(computer) || (!RedLived && !BlueLived)))
            {
                Tie = true;
                gameOver = true;
            }

            if (gameOver)
            {
                GameOverEventHandler(this, new EventArgs());
            }
        }

        #region section for raising the events
        #region pause
        public bool Pause
        {
            get { return this.gamePaused; }
            set { this.gamePaused = value; }
        }

        public event EventHandler PauseGameEventHandlerVariable;

        public void pauseGame(object sender, EventArgs e = null)
        {
            if (gameStarted)
            {
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
            else
            {
                StartGameEvent(e);
            }

        }


        public delegate void PauseGameEventHandler(object sender, EventArgs e);

        public void PauseGameEvent(EventArgs e)
        {
            EventHandler handler = PauseGameEventHandlerVariable;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region starting
        public bool Started
        {
            get { return this.gamePaused; }
            set { this.gamePaused = value; }
        }

        public event EventHandler GameStartEventHandler;

        public void GameStart(object sender, EventArgs e = null)
        {

            gamePaused = false;
            gameStarted = true;
            moveTimer.Enabled = true;
            GameOverEventHandler += GameOver;
        }

        public delegate void GameStartEventHandlerDelegate(object sender, EventArgs e);

        public void StartGameEvent(EventArgs e)
        {
            EventHandler handler = GameStartEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region Ending
        public bool gameOverSetandGet
        {
            get { return this.gameOver; }
            set { this.gameOver = value; }
        }

        public event EventHandler GameOverEventHandler;

        public void GameOver(object sender, EventArgs e = null)
        {
            moveTimer.Enabled = false;
            //gamePaused = true;
            gameOver = true;
           
            lblMessage.Top = Height / 4;
            if (!vComputer)
            {
                if (Tie)
                {
                    if (human.overlap(computer))
                    {
                        lblMessage.Text = "Suicide is not permitted.";
                    }
                    else
                    {
                        lblMessage.Text = "You two are well Matched!";
                    }
                }
                else if (RedLived && !BlueLived)
                {
                    lblMessage.Text = "Red WON!";
                }
                else
                {
                    lblMessage.Text = "Blue WON!";
                }
            }
            else
            {
                if (RedLived && !BlueLived)
                {
                    lblMessage.Text = "YOU WON! :)";
                }
                else
                {
                    lblMessage.Text = "You Lost :(";
                }
            }
            lblMessage.Left = (this.Width - lblMessage.Width) / 2;
            lblMessage.Visible = true;
        }

        public delegate void GameOverEventHandlerDelegate(object sender, EventArgs e);

        public void GameOverEvent(EventArgs e)
        {
            EventHandler handler = GameOverEventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
        #endregion
    }


}
