using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightningBugs
{
    
    public partial class Form1 : Form
    {
        Game game1;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createNewGame();
            newGameScreen1.StartGameTime += startGame;
        }

        bool creatingANewGame;
        private void createNewGame()
        {
            creatingANewGame = true;
            int height = Screen.PrimaryScreen.Bounds.Height - 100;//get the workable height of the screen (-40 for taskbar)
            int width = Screen.PrimaryScreen.Bounds.Width;//get workable width of screen
            //this.WindowState = FormWindowState.Maximized;//maximize the window
            this.Height = 336;
            this.Width = 311;
            Top = (height-Height)/2;
            Left = (width-Width)/2;
            creatingANewGame = true;
            //this.WindowState = FormWindowState.Normal;//maximize the window
            
            lblLevel.Visible = false;
            lblMode.Visible = false;
            btnToggle.Visible = false;
            lblTime.Visible = false;
            btnNewGame.Visible = false;
            lblInstructions.Visible = false;
            if (game1 != null)
            {
                game1.Visible = false;
            }
            //btnContinue.Click += pauseGame;
            //btnToggle.Click += pauseGame;



            //newGameScreen1.Left = (this.Width - newGameScreen1.Width) / 2;
            //newGameScreen1.Top = (this.Height - newGameScreen1.Height) / 2;

            Text = "Lightning Bugs";//set the display name
            newGameScreen1.Visible = true;

        }

        private void startGame(object sender, EventArgs e)
        {
            creatingANewGame = false;
            
            newGameScreen1.Visible = false;
            int height = Screen.PrimaryScreen.Bounds.Height - 100;//get the workable height of the screen (-40 for taskbar)
            int width = Screen.PrimaryScreen.Bounds.Width;//get workable width of screen
            //this.WindowState = FormWindowState.Maximized;//maximize the window
            this.Height = height;//then set the screen size to exactly what we want
            this.Width = width;
            Top = 0;
            Left = 0;


            lblLevel.Visible = true;
            lblMode.Visible = true;
            
            //btnToggle.Visible = true;

            if (newGameScreen1.radioButton1.Checked)
            {
                lblMode.Text = "Mode: Versus Computer";
            }
            else
            {
                lblMode.Text = "Mode: Two Players";
            }
            lblMode.Width = lblMode.Text.Length * 2;


            lblLevel.Left = 10;
            lblMode.Left = Width - 10 - lblMode.Width;
            btnToggle.Left = (Width - btnToggle.Width) / 2;
            btnContinue.Left = (Width - btnContinue.Width) / 2;
            lblTime.Left = (lblMode.Left - btnToggle.Left) / 2 + btnToggle.Left;
            btnNewGame.Left = (Width - btnNewGame.Width) / 2;

            lblLevel.Top = Height - 100;
            lblMode.Top = Height - 100;
            btnToggle.Top = Height - 100;
            btnContinue.Top = Height - 100;
            lblTime.Top = Height - 100;
            btnNewGame.Top = Height - 100;


            lblLevel.Text = "Level: " + newGameScreen1.comboBox1.SelectedItem.ToString();

            game1 = new Game(newGameScreen1.radioButton1.Checked,newGameScreen1.comboBox1.SelectedIndex);
            game1.Top = 10;//put the game in top left corner
            game1.Left = 0;
            game1.Height = height;//expand to be workable size of program
            game1.Width = width;
            game1.Top = game1.Left = 0;
           

            //Text = "Lightning Bugs";//set the display name

            Controls.Add(game1);
            game1.Visible = true;
            game1.Focus();
            game1.PauseGameEventHandlerVariable += this.pauseGame;
            game1.PauseGameEventHandlerVariable += game1.pauseGame;
            game1.GameStartEventHandler += this.gameStarting;
            game1.GameStartEventHandler += game1.GameStart;

            btnToggle.Click += game1.pauseGame;
            btnContinue.Click += game1.pauseGame;

            game1.GameOverEventHandler += this.GameOver;

            lblInstructions.Visible = true;
            lblInstructions.Text = "Press any key to start.\nYou can use Space bar, Return or \"p\" to pause the game.";
            lblInstructions.Left = (width - lblInstructions.Width) / 2;
            lblInstructions.Top = Height / 4;
        }

        private void pauseGame(object sender, EventArgs e)
        {
            lblInstructions.Text = "Press any key to continue.";
            lblInstructions.Left = (Width - lblInstructions.Width) / 2;
            if (!game1.gameOver)
            {
                btnToggle.Visible = !btnToggle.Visible;
                btnContinue.Visible = !btnContinue.Visible;
                lblInstructions.Visible = !lblInstructions.Visible;
                if (btnContinue.Visible)
                {
                    LiveTimer.Enabled = false;
                    pauseTime = DateTime.Now;
                }
                else
                {
                    pauseTimeElapsed = DateTime.Now-pauseTime;
                    LiveTimer.Enabled = true;
                }
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            //thought this would remaximize the window once moved - no go.
            
            if(!creatingANewGame)
            {
                int height = Screen.PrimaryScreen.Bounds.Height;//get the workable height of the screen (-40 for taskbar)
                int width = Screen.PrimaryScreen.Bounds.Width;//get workable width of screen
                //this.WindowState = FormWindowState.Maximized;//maximize the window
                this.Height = height;//then set the screen size to exactly what we want
                this.Width = width;
                Top = 0;
                Left = 0;
            }
            //int height = Screen.PrimaryScreen.Bounds.Height - 100;//get the workable height of the screen (-40 for taskbar)
            //int width = Screen.PrimaryScreen.Bounds.Width;//get workable width of screen

            //this.Height = height;//then set the screen size to exactly what we want
            //this.Width = width;
            //Top = 0;
            //Left = 0;
        }

        private void gameStarting(object sender, EventArgs e)
        {
            btnToggle.Visible = true;
            btnContinue.Visible = false;
            lblTime.Visible = true;
            LiveTimer.Enabled = true;
            startTime = DateTime.Now;
        }

        static TimeSpan pauseTimeElapsed;
        static DateTime pauseTime;
        static DateTime startTime;

        private void LiveTimer_Tick(object sender, EventArgs e)
        {
                //DateTime now = new DateTime();
                TimeSpan elapsedTime = DateTime.Now - startTime - pauseTimeElapsed;
                lblTime.Text = "";
                if (elapsedTime.Minutes.ToString().Length < 2)
                {
                    lblTime.Text = "0";
                }
                lblTime.Text += elapsedTime.Minutes.ToString() + ":";

                if (elapsedTime.Seconds.ToString().Length < 2)
                {
                    lblTime.Text += "0";
                }
                lblTime.Text += elapsedTime.Seconds.ToString() + "." + elapsedTime.Milliseconds.ToString().Substring(0,1);
        }

        private void GameOver(object sender, EventArgs e)
        {
            LiveTimer.Enabled = false;
            btnToggle.Visible = false;
            btnNewGame.Visible = true;
            btnNewGame.Focus();
            lblInstructions.Text = "Good game!\nPress New Game for more fun or just exit (don't... please!).";
            lblInstructions.Left = (Width - lblInstructions.Width) / 2;
            lblInstructions.Visible = true;
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            createNewGame();
        }
    }
}
