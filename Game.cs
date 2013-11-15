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
            computer = new Player(Resource1.carRed);
            computer.turn(Direction.down);
            Controls.Add(human);
            Controls.Add(computer);
            InitializeComponent();
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

            human.Refresh();

            return true;
        }

        public void movePieces()
        {
        }
    }
}
