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

        //public override void turn(Direction d)
        //{
        //    while (direction.CompareTo(d) != 0)
        //    {
        //        int temp = Width;

        //        KeyValuePair<int, int> pos = getPosition();
        //        int x = pos.Key;
        //        int y = (pos.Value);

        //        if (direction.CompareTo(d) < 0)
        //        {
        //            Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
        //            //if (direction.getDirection() == Direction.down)
        //            //{
        //            //    x -= Height / 2;
        //            //}
        //            direction.decrement();
        //        }
        //        else
        //        {
        //            Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
        //            //if (direction.getDirection() == Direction.up)
        //            //{
        //            //    x += Height / 2;
        //            //}
        //            direction.increment();
        //        }
        //        Width = Height;
        //        Height = temp;

        //        //KeyValuePair<int, int> posFinal = getTrunkPosition();
        //        Top = y - (Height / 2);
        //        Left = x - (Width / 2);
        //    }
        //}

        public void turn(ControlCollection Controls)
        {
            //KeyValuePair<int, int> pos = getPosition();
            List<Direction> options = new List<Direction>();
            Direction temp = direction.getDirection();
            
            //checkControls.Remove(this);
            //exam going up
            options.Add(Direction.up);//add all possible directions to be removed as they become not options
            options.Add(Direction.down);
            options.Add(Direction.left);
            options.Add(Direction.right);

            //Controls.Remove(this);//remove self from list to check against.
            turn(Direction.up);
            foreach (GameImage image in Controls)
            {
                if (image != this && (overlap(image) || Top <= 2))
                {
                    options.Remove(Direction.up);
                }
            }
            turn(Direction.down);
            foreach (GameImage image in Controls)
            {
                if (image != this && (overlap(image) || Bottom >= Screen.PrimaryScreen.Bounds.Height - 60))
                {
                    options.Remove(Direction.down);
                }
            }
            turn(Direction.left);
            foreach (GameImage image in Controls)
            {
                if (image != this && (overlap(image) || Left < 0 || Top <= 0))
                {
                    options.Remove(Direction.left);
                }
            }
            turn(Direction.right);
            foreach (GameImage image in Controls)
            {
                if (image != this && (overlap(image) || Top <= 0 /*|| Right > Screen.PrimaryScreen.Bounds.Width*/))
                {
                    options.Remove(Direction.right);
                }
            }
            Random randomChoice = new Random();
            turn(temp);//return orientation to original

            //check to see if can continue in current direction
            move(new GameImage(Resource1.carBlue));
            bool canContinue = true;
            foreach (GameImage image in Controls)
            {
                if (image != this && overlap(image))
                {
                    canContinue = false;
                }
            }
            if (canContinue)
            {
                int optionCount = options.Count;
                optionCount *= optionCount;
                for (int i = 0; i < optionCount; i++)
                {
                    options.Add(direction.getDirection());
                }
            }

            //move back to original pos by reversing direction, moving, and reversing again.
            direction.increment();
            direction.increment();
            move(new GameImage(Resource1.carBlue));
            direction.increment();
            direction.increment();

            if (options.Count > 0)
            {
                turn(options.ElementAt(randomChoice.Next() % options.Count()));
            }
            //Controls.Add(this);
        }
    }
}
