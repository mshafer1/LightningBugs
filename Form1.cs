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
            lblLevel.Visible = false;
            lblMode.Visible = false;
            btnToggle.Visible = false;
            //btnContinue.Click += pauseGame;
            //btnToggle.Click += pauseGame;
            newGameScreen1.StartGameTime += startGame;
            
            //newGameScreen1.Left = (this.Width - newGameScreen1.Width) / 2;
            //newGameScreen1.Top = (this.Height - newGameScreen1.Height) / 2;
            
            Text = "Lightning Bugs";//set the display name
            newGameScreen1.Visible = true;
        }

        private void startGame(object sender, EventArgs e)
        {
            newGameScreen1.Visible = false;
            int height = Screen.PrimaryScreen.Bounds.Height - 100;//get the workable height of the screen (-40 for taskbar)
            int width = Screen.PrimaryScreen.Bounds.Width;//get workable width of screen
            this.WindowState = FormWindowState.Maximized;//maximize the window
            //this.Height = height;//then set the screen size to exactly what we want
            //this.Width = width;

            lblLevel.Visible = true;
            lblMode.Visible = true;
            btnToggle.Visible = true;

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
            lblMode.Left = width - 10 - lblMode.Width;
            btnToggle.Left = (width - btnToggle.Width) / 2;
            btnContinue.Left = (width - btnContinue.Width) / 2;

            lblLevel.Top = Height-100;
            lblMode.Top = Height - 100;
            btnToggle.Top = Height - 100;
            btnContinue.Top = Height - 100;

            lblLevel.Text = "Level: " + newGameScreen1.comboBox1.SelectedItem.ToString();

            game1 = new Game(newGameScreen1.radioButton1.Checked,newGameScreen1.comboBox1.SelectedIndex);
            game1.Top = 10;//put the game in top left corner
            game1.Left = 0;
            game1.Height = height;//expand to be workable size of program
            game1.Width = width;
            game1.Top = game1.Left = 0;
           

            Text = "Lightning Bugs";//set the display name

            Controls.Add(game1);
            game1.Visible = true;
            game1.Focus();
            game1.PauseGameEventHandlerVariable += this.pauseGame;
            game1.PauseGameEventHandlerVariable += game1.pauseGame;
            lblInstructions.Visible = true;
            lblInstructions.Text = "Press any key to continue.";
            lblInstructions.Left = (width - lblInstructions.Width) / 2;
            //game1.PauseGame += pauseGame;
        }

        private void pauseGame(object sender, EventArgs e)
        {
            if (!game1.gameOver)
            {
                btnToggle.Visible = !btnToggle.Visible;
                btnContinue.Visible = !btnContinue.Visible;
                lblInstructions.Visible = !lblInstructions.Visible;
            }
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            //thought this would remaximize the window once moved - no go.
            this.WindowState = FormWindowState.Maximized;//maximize the window
            int height = Screen.PrimaryScreen.Bounds.Height - 100;//get the workable height of the screen (-40 for taskbar)
            int width = Screen.PrimaryScreen.Bounds.Width;//get workable width of screen
            
            this.Height = height;//then set the screen size to exactly what we want
            this.Width = width;
        }
    }
}
