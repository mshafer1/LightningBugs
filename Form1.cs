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
            //Rectangle resolution = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            //Width = resolution.X;
            //Height = resolution.Y;
            InitializeComponent();
            //Icon = Resource1.picture2;
            Rectangle resolution = Screen.PrimaryScreen.Bounds;
            int height = Screen.PrimaryScreen.Bounds.Height-40;
            int width = Screen.PrimaryScreen.Bounds.Width;
            this.WindowState = FormWindowState.Maximized;
            this.Height = height;
            this.Width = width;
            game1.Top = 0;
            game1.Left = 0;
            game1.Height = height - 20;
            game1.Width = width;
            game1.Top = game1.Left = 0;
            Text = "Lightning Bugs";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Player test = new Player(/*Resource1.carRed*/);
            //Controls.Add(test);
            //test.turn(Direction.down);
            //test.BringToFront();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // game1.movePieces();
        }
    }
}
