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
            game1.movePieces();
        }
        

       

        
    }
}
