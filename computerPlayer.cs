using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SelfBalancedTree;

namespace LightningBugs
{
    class computerPlayer : Player
    {
        public computerPlayer(Image image)
            : base(image)
        {
        }

        public computerPlayer(computerPlayer copy)
            : base(copy.Image)
        {
            Top = copy.Top;
            Left = copy.Left;
            direction = copy.direction;
            Width = copy.Right - copy.Left;
            Height = copy.Bottom - copy.Top;
            length = copy.length;
            
        }



        public void turn(ControlCollection Controls)
        {
            if ((moveCount + 1) % 2 == 1)
            {
                List<Direction> options = new List<Direction>();
                Direction temp = direction.getDirection();

                //add all possible directions to be removed as they become not options
                options.Add(Direction.up);
                options.Add(Direction.down);
                options.Add(Direction.left);
                options.Add(Direction.right);

                AVLTree<GameImage> trails = SingletonTrailTree.getInstance();

                computerPlayer tempPlayer = new computerPlayer(this);

                tempPlayer.turn(Direction.up);
                if (trails.Contains(tempPlayer) || tempPlayer.Top <= 2)
                {
                    options.Remove(Direction.up);
                }

                tempPlayer.turn(Direction.down);
                if (trails.Contains(tempPlayer) || tempPlayer.Bottom >= Screen.PrimaryScreen.Bounds.Height - 100)
                {
                    options.Remove(Direction.down);
                }

                tempPlayer.turn(Direction.left);
                if (trails.Contains(tempPlayer) || tempPlayer.Left <= -20 || tempPlayer.Top <= -10 || tempPlayer.Right >= Screen.PrimaryScreen.Bounds.Width - 100)
                {
                    options.Remove(Direction.left);
                }

                tempPlayer.turn(Direction.right);
                if (trails.Contains(tempPlayer) || tempPlayer.Top <= -10 || tempPlayer.Right >= Screen.PrimaryScreen.Bounds.Width - 100)
                {
                    options.Remove(Direction.right);
                }

                //return orientation to original
                tempPlayer.turn(temp);

                //check to see if can continue in current direction
                tempPlayer.move(new GameImage(Resource1.carBlue));
                bool canContinue = true;
                if (trails.Contains(tempPlayer) ||
                    !
                    (tempPlayer.Top > 2 && tempPlayer.Left > 2
                    && tempPlayer.Right < Screen.PrimaryScreen.Bounds.Width
                    && tempPlayer.Bottom < Screen.PrimaryScreen.Bounds.Height - 100)
                    )
                {
                    canContinue = false;
                }

                if (canContinue)
                {
                    int optionCount = 40;
                    for (int i = 0; i < optionCount; i++)
                    {
                        options.Add(direction.getDirection());
                    }
                }
                else
                {
                    options.Remove(temp);
                }

                Random randomChoice = new Random();
                if (options.Count > 0)
                {
                    turn(options.ElementAt(randomChoice.Next() % options.Count()));
                }
            }
        }
    }
}
