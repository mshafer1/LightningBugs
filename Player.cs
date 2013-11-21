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

        public Player(Image image): base(image)
        {
            InitializeComponent();
            direction = new DrirectionClass();
            this.Height = image.Height;
            this.Width = image.Width;
            this.length = Height;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public virtual void turn(Direction d)
        {
            while (direction.CompareTo(d) != 0)
            { int temp = Width;

                KeyValuePair<int, int> pos = getPosition();
                int x = pos.Key;
                int y = (pos.Value);


                pos = getTrunkPosition();
                int x0 = pos.Key;
                int y0 = pos.Value;
                
                //if (direction.CompareTo(d) < 0)
                //{
                   Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
                    //if (direction.getDirection() == Direction.down)
                    //{
                    //    x -= Height / 2;
                    //}
                   direction.decrement();
                //}
                //else
                //{
                    //Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    //if (direction.getDirection() == Direction.up)
                    //{
                    //    x += Height / 2;
                    //}
                    //direction.increment();
                //}
                Width = Height;
                Height = temp;

                //KeyValuePair<int, int> posFinal = getTrunkPosition();
                Top = y - (Height / 2);
                Left = x - (Width / 2);

                Left = x0 - (int)((float)Width / 2);
                Top = y0 - Height;
            }
        }

        public void move(GameImage trail)
        {
            int moveLength = this.length/2;
            
            trail.Height = moveLength;
            if (this.direction.getDirection() == Direction.up)
            {
                trail.Top = (int)(this.Top + Height-moveLength);//Height - moveLength is position from front of car that trail should end before car is moved
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
            KeyValuePair<int, int> result = new KeyValuePair<int, int>(Left + Width / 2, Top + Height / 2);
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
            KeyValuePair<int, int> result = new KeyValuePair<int,int>();
            switch (direction.getDirection())
            {
                case(Direction.up):
                    result = new KeyValuePair<int, int>(Left + Width / 2, Top);
                    break;
                case(Direction.down):
                    result = new KeyValuePair<int, int>(Left + Width / 2, Top + Height);
                    break;
                case(Direction.left):
                    result = new KeyValuePair<int, int>(Left, Top + Height / 2);
                    break;
                case(Direction.right):
                    result = new KeyValuePair<int, int>(Left+Width, Top + Height /2);
                    break;
            }
            return result;
        }

        int length;
        public DrirectionClass direction;
    }
}
