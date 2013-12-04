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
            Height = copy.Bottom- copy.Top;
            length = copy.length;
        }

        

        public void turn(ControlCollection Controls)
        {
            
            List<Direction> options = new List<Direction>();
            Direction temp = direction.getDirection();
            
       
          
            options.Add(Direction.up);//add all possible directions to be removed as they become not options
            options.Add(Direction.down);
            options.Add(Direction.left);
            options.Add(Direction.right);

            
            computerPlayer tempPlayer = new computerPlayer(this);
            tempPlayer.turn(Direction.up);
            //examine going up
          
            foreach (GameImage image in Controls)
            {
                if (image != this && (tempPlayer.Top <= 2 || tempPlayer.overlap(image)))
                {
                    options.Remove(Direction.up);
                }
            }
            tempPlayer.turn(Direction.down);
            foreach (GameImage image in Controls)
            {

                if (image != this && (tempPlayer.Bottom >= Screen.PrimaryScreen.Bounds.Height - 500 || tempPlayer.overlap(image)))
                {
                    options.Remove(Direction.down);
                }
            }
            tempPlayer.turn(Direction.left);
            foreach (GameImage image in Controls)
            {
                if (image != this && ( tempPlayer.Left <= -20 || tempPlayer.Top <= -10 || tempPlayer.Right >= Screen.PrimaryScreen.Bounds.Width - 100 || tempPlayer.overlap(image)) )
                {
                    options.Remove(Direction.left);
                }
            }
            tempPlayer.turn(Direction.right);
            foreach (GameImage image in Controls)
            {
                if (image != this && ( tempPlayer.Top <= 0 || tempPlayer.Right > Screen.PrimaryScreen.Bounds.Width || tempPlayer.overlap(image)))
                {
                    options.Remove(Direction.right);
                }
            }

            tempPlayer.turn(temp);//return orientation to original

            ////check to see if can continue in current direction
            tempPlayer.move(new GameImage(Resource1.carBlue));
            bool canContinue = true;
            foreach (GameImage image in Controls)
            {
                if (image != this && tempPlayer.overlap(image))
                {
                    canContinue = false;
                }
            }
            if (!(tempPlayer.Top > 2 && tempPlayer.Left > 2 && tempPlayer.Right < Screen.PrimaryScreen.Bounds.Width && tempPlayer.Bottom < Screen.PrimaryScreen.Bounds.Height-100))
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
