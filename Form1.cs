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
        public GameForm()
        {
            InitializeComponent();//call provided constructor

            int height = Screen.PrimaryScreen.Bounds.Height-40;//get the workable height of the screen (-40 for taskbar)
            int width = Screen.PrimaryScreen.Bounds.Width;//get workable width of screen
            this.WindowState = FormWindowState.Maximized;//maximize the window
            this.Height = height;//then set the screen size to exactly what we want
            this.Width = width;
            game1.Top = 0;//put the game in top left corner
            game1.Left = 0;
            game1.Height = height - 20;//expand to be workable size of program
            game1.Width = width;
            game1.Top = game1.Left = 0;
            Text = "Lightning Bugs";//set the display name
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //testing code
            //Player test = new Player(/*Resource1.carRed*/);
            //Controls.Add(test);
            //test.turn(Direction.down);
            //test.BringToFront();
        }

        
    }
}
