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
    public partial class GameForm : Form
    {
        //public static bool startButton;
        //public static bool pauseButton;
        //public static bool newGameButton;
        
        public GameForm()
        {
            InitializeComponent();//call provided constructor

            int height = Screen.PrimaryScreen.Bounds.Height-40;//get the workable height of the screen (-40 for taskbar)
            int width = Screen.PrimaryScreen.Bounds.Width;//get workable width of screen
            this.WindowState = FormWindowState.Maximized;//maximize the window
            this.Height = height;//then set the screen size to exactly what we want
            this.Width = width;
            game1.Top = 10;//put the game in top left corner
            game1.Left = 0;
            game1.Height = height - 20;//expand to be workable size of program
            game1.Width = width;
            game1.Top = game1.Left = 0;
            button1.Top = height - 17;
            button1.Left = width / 2;
            //button2.Visible = true;
            radioButton1.Top = height - 19;
            radioButton1.Left = width / 2 - 90;
            radioButton2.Top = height - 4;
            radioButton2.Left = width / 2 - 90;
            //Playing against the computer is the default
            Class1.vComputer = true;
            Text = "Lightning Bugs";//set the display name
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //This is made so the user can start the game by pressing Enter
            button1.Focus();
            


            //testing code
            //Player test = new Player(/*Resource1.carRed*/);
            //Controls.Add(test);
            //test.turn(Direction.down);
            //test.BringToFront();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Class1.vComputer = true;
            game1.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Class1.vComputer = false;
            game1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Class1.startClick = true;
            game1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            BackColor = Color.Green;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            BackColor = Color.Gray;
        }
    }
}
