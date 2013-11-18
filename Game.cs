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
        public Game()
        {
            human = new Player(Resource1.carRed);
            computer = new computerPlayer(Resource1.carBlue);

            Controls.Add(human);
            Controls.Add(computer);
            InitializeComponent();
            computer.turn(Direction.down);
        }

        private void Game_Load(object sender, EventArgs e)
        {
            computer.Left = human.Left = ClientRectangle.Width / 2 - human.Width / 2;
            computer.Top = 0;
            human.Top = /*computer.Top + computer.Height*2;//*/ClientRectangle.Height - human.Height;
        }



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


            return true;
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            GameImage humanTrail = new GameImage(Resource1.trailRed);
            human.move(humanTrail);
            Controls.Add(humanTrail);

            GameImage computerTrail = new GameImage(Resource1.trailBlue);
            computer.move(computerTrail);
            Controls.Add(computerTrail);

            int check = checkForDeath();
            switch (check)
            {
                case (1): moveTimer.Enabled = false; MessageBox.Show("You lost"); break;
                case (2): moveTimer.Enabled = false; MessageBox.Show("You WIN"); break;
            }

            ///computer.move(Resource1.trailBlue);
        }

        private int checkForDeath()
        {
            int result = 0;
            if (human.checkForDeath(this.Width,this.Height))
            {
                result = 1;
            }
            else if (computer.checkForDeath(this.Width, this.Height))
            {
                result = 2;
            }
            return result;
        }
    }
}
