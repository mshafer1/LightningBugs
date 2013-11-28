﻿using System;
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
        private static Player human;
        private static computerPlayer computer;
        private static int moveCount;
        public Game()
        {
            human = new Player(Resource1.carRed);
            computer = new computerPlayer(Resource1.carBlue);

            Controls.Add(human);
            Controls.Add(computer);
            InitializeComponent();
            computer.turn(Direction.down);
            //computer.turn(Direction.left);//remove later
            
        }

        private void Game_Load(object sender, EventArgs e)
        {
            computer.Left = human.Left = ClientRectangle.Width / 2 - human.Width / 2;
            computer.Top = 0;
            //computer.Top = 72;//remove later
            human.Top = ClientRectangle.Height - human.Height;
            moveCount = 0;

        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //when game loads, timer is not enabled, this will enable it on first key press making game start on any key.
            if (moveTimer.Enabled == false)
            {
                moveTimer.Enabled = true;
            }

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

            if (human.direction.getDirection() != human0 || computer.direction.getDirection() != computer0 && false)
            {
                switch (checkForDeath())
                {
                    case (1): moveTimer.Enabled = false; MessageBox.Show("You lost"); break;
                    case (2): moveTimer.Enabled = false; MessageBox.Show("You WIN"); break;
                }
            }


            return true;
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            moveCount++;
            
            GameImage humanTrail = new GameImage(Resource1.trailRed);
            human.move(humanTrail);
            Controls.Add(humanTrail);

            switch (checkForDeath())
            {
                case (1): moveTimer.Enabled = false; MessageBox.Show("You lost"); break;
                case (2): moveTimer.Enabled = false; MessageBox.Show("You WIN"); break;
            }

            GameImage computerTrail = new GameImage(Resource1.trailBlue);

            if (Class1.vComputer)
            {
                computer.turn(Controls);
            }
            computer.move(computerTrail);
            Controls.Add(computerTrail);
            
            
            
            switch (checkForDeath())
            {
                case (1): moveTimer.Enabled = false; MessageBox.Show("You lost"); break;
                case (2): moveTimer.Enabled = false; MessageBox.Show("You WIN"); break;
            }

            
        }

        private int checkForDeath()
        {
            int result = 0;

            foreach (GameImage image in Controls)
            {

                KeyValuePair<int, int> pos = human.getFrontPosition();
                KeyValuePair<int, int> piecePos = image.centerPos();
                
                if (image != human && human.overlap(image) || (human.Top < -20 || human.Left < -20 || human.Bottom >= this.Height+20 || human.Right >= this.Width+20))
                {
                    //MessageBox.Show("You lost");
                    result = 1;
                }

                pos = computer.getFrontPosition();

                if (image != computer && computer.overlap(image) || (computer.Top < -20 || computer.Left < -20 || computer.Bottom > this.Height+20 || computer.Right > this.Width+20))
                {
                    //MessageBox.Show("You lost");
                    result = 2;
                }
            }
            return result;
        }

        
    }
}
