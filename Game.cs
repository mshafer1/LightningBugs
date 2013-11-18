using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightningBugs
{
    public partial class Game : UserControl
    {
        public Game()
        {
            human = new Player(Resource1.carRed);
            computer = new Player(Resource1.carBlue);

            Controls.Add(human);
            Controls.Add(computer);
            InitializeComponent();
            computer.turn(Direction.down);
        }

        private void Game_Load(object sender, EventArgs e)
        {
            computer.Left = human.Left = ClientRectangle.Width / 2 - human.Width / 2;
            computer.Top = 0;
            human.Top = ClientRectangle.Height - human.Height;
        }

        private static Player human, computer;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
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

            
            return true;
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            human.move(Resource1.trailRed);
            GameImage myTrail = new GameImage(Resource1.trailRed);
            myTrail.Visible = true;
            if (human.direction.getDirection() == Direction.up)
            {
                myTrail.Top = (int)(human.Top + (float)human.Height / 2 + 0.5);
                myTrail.Left = (int)(human.Left + (float)(human.Width - myTrail.Width) / 2);
                human.Top -= (int)((float)human.Height / 2 + 0.5);
            }
            else if (human.direction.getDirection() == Direction.down)
            {
                myTrail.Top = (int)(human.Top);
                myTrail.Left = (int)(human.Left + (float)(human.Width - myTrail.Width) / 2);
                human.Top += (int)((float)human.Height / 2 + 0.5);
            }
            else if (human.direction.getDirection() == Direction.left)
            {
                myTrail.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                int temp = myTrail.Width;
                myTrail.Width = myTrail.Height;
                myTrail.Height = temp;
                myTrail.Top = (int)(human.Top + (float)(human.Height - myTrail.Height) / 2 + 0.5);
                myTrail.Left = human.Left + human.Width - myTrail.Width;
                human.Left -= (int)((float)human.Width  / 2 + 0.5);
                
            }
            else if (human.direction.getDirection() == Direction.right)
            {
                myTrail.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                int temp = myTrail.Width;
                myTrail.Width = myTrail.Height;
                myTrail.Height = temp;
                myTrail.Top = (int)(human.Top + (float)(human.Height - myTrail.Height) / 2 + 0.5);
                myTrail.Left = human.Left;
                human.Left += (int)((float)human.Width / 2 + 0.5);
            }
            Controls.Add(myTrail);
            switch (checkForDeath())
            {
                case (1): moveTimer.Enabled = false; MessageBox.Show("You lost"); break;
                case (2): moveTimer.Enabled = false; MessageBox.Show("You WIN"); break;
            }
            
            ///computer.move(Resource1.trailBlue);
        }

        private int checkForDeath()
        {
            int result = 0;

            foreach(GameImage image in Controls)
            {
                
                KeyValuePair<int,int> pos = human.getFrontPosition();
                
                if (image != human && image.Top + image.Height >= pos.Value && 
                    pos.Value >= image.Top && 
                    image.Left <= pos.Key
                    && image.Left + image.Width >= pos.Key)
                {
                    //MessageBox.Show("You lost");
                    result = 1;
                }

                pos = computer.getFrontPosition();

                if (image.Top + Height < pos.Value && pos.Value < image.Top - Height && image.Left < pos.Key && image.Left + Width < pos.Key)
                {
                    if ((result) == 0)
                    {
                        //MessageBox.Show("You WIN");
                        result = 2;
                    }
                }
            }
            return result;
        }
    }
}
