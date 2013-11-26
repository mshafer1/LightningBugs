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
    public partial class Player : GameImage
    {
        protected int length;
        int width;
        public DrirectionClass direction;
        public Player(Image image)
            : base(image)
        {
            InitializeComponent();
            direction = new DrirectionClass();
            this.Height = 72;
            this.Width = 36;
            this.length = Height;
            this.width = Width;
        }

        private int ceil(float input)
        {
            int result = (int)input;
            if (result - input > 0)
            {
                result++;
            }
            return result;
        }

        private int divideByTwoWithRounding(int input)
        {
            int result = (int)((float)((input / 2 + .5)));
            return result;

        }

        public virtual void turn(Direction d)
        {
            //If the direction of the player is not equal to the direction the player wants to move to
            while (direction.getDirection() != d)
            {
                //Getting actual position of trunk
                KeyValuePair<int, int> pos = getPosition();
                int x = pos.Key;
                int y = pos.Value;

                //Rotating 90 degrees clockwise
                Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
                int temp = this.Width;
                this.Width = this.Height;
                this.Height = temp;
                Top = y - Height / 2;
                Left = x - Width / 2;

                switch (direction.getDirection())
                {
                    // up going right
                    case (Direction.up):
                        Left += abs(this.Height - Width) - 1;
                        Top += divideByTwoWithRounding(this.Width);
                        break;
                    //Down turning left
                    case (Direction.down):
                        Left -= abs(this.Height - Width) - 1;
                        Top -= divideByTwoWithRounding(this.Width);
                        break;

                    //left turning up
                    case (Direction.left):
                        Left += divideByTwoWithRounding(this.Height);
                        Top -= abs(this.Height - this.Width) - 1;
                        break;
                    //right turning down
                    case (Direction.right):
                        Left -= divideByTwoWithRounding(this.Height);
                        Top += abs(this.Height - this.Width) - 1;
                        break;
                }



                direction.decrement();
            }
        }

        public void move(GameImage trail)
        {
            int moveLength = 5;

            trail.Height = moveLength;
            trail.Width = 4;
            if (this.direction.getDirection() == Direction.up)
            {
                trail.Top = (int)(this.Top + Height - moveLength);//Height - moveLength is position from front of car that trail should end before car is moved
                trail.Left = (int)(this.Left + (float)(this.Width - trail.Width) / 2);//by dividing the diference of the widths by two, we get half of the margin to put on one side.

                this.Top -= (int)(moveLength);
            }
            else if (this.direction.getDirection() == Direction.down)
            {
                trail.Top = (int)(this.Top);
                trail.Left = (int)(this.Left + (float)(this.Width - trail.Width) / 2);

                this.Top += (int)(moveLength);
            }
            else
            {
                trail.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);//orient the trail horizontally.
                int temp = trail.Width;
                trail.Width = trail.Height;
                trail.Height = temp;

                trail.Top = (this.Top + (this.Height - trail.Height) / 2);//position trail in center of car vertically.
                if ((this.direction.getDirection() == Direction.left))
                {
                    trail.Left = this.Left + this.Width - moveLength;

                    this.Left -= (int)(moveLength);
                }
                else
                {
                    trail.Left = this.Left;

                    this.Left += (int)(moveLength);
                }
            }
        }

        public void move(Image image)
        {

        }

        public KeyValuePair<int, int> getPosition()
        {
            KeyValuePair<int, int> result = new KeyValuePair<int, int>(Left + (Width / 2), Top + (Height / 2));

            return result;
        }

        public KeyValuePair<int, int> getTrunkPosition()
        {
            int trunkx = Left + Width / 2; // assuming up, horizontal center
            int trunky = Top + Height; //vertical bottom

            switch (direction.getDirection())
            {
                case (Direction.up): break;
                case (Direction.down):
                    trunky = Top; //if headed down; however, move vertical to top
                    break;
                case (Direction.left):
                    trunky = (int)(Top + (float)Height / 2); //if moving horizontally, totally redo
                    trunkx = Left + Width;
                    break;
                case (Direction.right):
                    trunky = (int)(Top + (float)Height / 2);
                    trunkx = Left;
                    break;
            }
            KeyValuePair<int, int> result = new KeyValuePair<int, int>(trunkx, trunky);//create a pair of int using determined x and y
            return result;//return this pair
        }

        public KeyValuePair<int, int> getFrontPosition()
        {
            KeyValuePair<int, int> result = new KeyValuePair<int, int>();
            switch (direction.getDirection())
            {
                case (Direction.up):
                    result = new KeyValuePair<int, int>(Left + Width / 2, Top);
                    break;
                case (Direction.down):
                    result = new KeyValuePair<int, int>(Left + Width / 2, Top + Height);
                    break;
                case (Direction.left):
                    result = new KeyValuePair<int, int>(Left, Top + Height / 2);
                    break;
                case (Direction.right):
                    result = new KeyValuePair<int, int>(Left + Width, Top + Height / 2);
                    break;
            }
            return result;
        }

        

        private int abs(int input)
        {
            int result = input;
            if (result < 0)
            {
                result *= -1;
            }
            return result;
        }

        public bool overlap(GameImage check)
        {
            bool result = false;
            KeyValuePair<int, int> carFrontPos = getFrontPosition();
            int threshold =  Width / 4 - 1;
            if(check.Left < Right-threshold && check.Right > Left+threshold)
            {
                if (check.Top < Bottom-threshold && check.Bottom > Top+threshold)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
