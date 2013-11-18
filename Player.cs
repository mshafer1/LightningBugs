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
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public virtual void turn(Direction d)
        {
            while (direction.CompareTo(d) != 0)
            { int temp = Width;

                KeyValuePair<int, int> pos = getTrunkPosition();
                int x = pos.Key;
                int y = (pos.Value);
                
                if (direction.CompareTo(d) < 0)
                {
                    Image.RotateFlip(RotateFlipType.Rotate270FlipXY);//turn 90 clockwise
                    Width = Height;
                    Height = temp;
                    KeyValuePair<int, int> posFinal = getTrunkPosition();
                    Top += pos.Value - posFinal.Value;
                    Left += posFinal.Key - pos.Key;
                    //if (direction.getDirection() == Direction.down)
                    //{
                    //    x -= Height / 2;
                    //}
                    direction.decrement();
                }
                else
                {
                    Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    Width = Height;
                    Height = temp;
                    KeyValuePair<int, int> posFinal = getTrunkPosition();
                    Top += pos.Value - posFinal.Value;
                    Left -=  posFinal.Key-pos.Key + Width/2;
                    //if (direction.getDirection() == Direction.up)
                    //{
                    //    x += Height / 2;
                    //}
                    direction.increment();
                }
               

                //KeyValuePair<int, int> posFinal = getTrunkPosition();
            }
        }

        public void move(GameImage trail)
        {
            if (this.direction.getDirection() == Direction.up)
            {
                trail.Top = (int)(this.Top + (float)this.Height / 2);
                trail.Left = (int)(this.Left + (float)(this.Width - trail.Width) / 2);
                this.Top -= (int)((float)this.Height / 2);
            }
            else if (this.direction.getDirection() == Direction.down)
            {
                trail.Top = (int)(this.Top);
                trail.Left = (int)(this.Left + (float)(this.Width - trail.Width) / 2);
                this.Top += (int)((float)this.Height / 2);
            }
            else if (this.direction.getDirection() == Direction.left)
            {
                trail.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                int temp = trail.Width;
                trail.Width = trail.Height;
                trail.Height = temp;
                trail.Top = (int)(this.Top + (float)(this.Height - trail.Height) / 2);
                trail.Left = this.Left + this.Width - trail.Width;
                this.Left -= (int)((float)this.Width / 2);

            }
            else if (this.direction.getDirection() == Direction.right)
            {
                trail.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                int temp = trail.Width;
                trail.Width = trail.Height;
                trail.Height = temp;
                trail.Top = (int)(this.Top + (float)(this.Height - trail.Height) / 2);
                trail.Left = this.Left;
                this.Left += (int)((float)this.Width / 2);
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
            KeyValuePair<int, int> result = new KeyValuePair<int, int>();
            switch (direction.getDirection())
            {
                case (Direction.up):
                    result = new KeyValuePair<int, int>(Left + Width / 2, Top + Height);
                    break;
                case (Direction.down):
                    result = new KeyValuePair<int, int>(Left + Width / 2, Top);
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


        public DrirectionClass direction;
    }
}
