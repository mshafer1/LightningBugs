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

        public void turn(Direction d)
        {
            while (direction.CompareTo(d) != 0)
            { int temp = Width;

                KeyValuePair<int, int> pos = getPosition();
                int x = pos.Key;
                int y = (pos.Value);
                
                if (direction.CompareTo(d) < 0)
                {
                    Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
                    //if (direction.getDirection() == Direction.down)
                    //{
                    //    x -= Height / 2;
                    //}
                    direction.decrement();
                }
                else
                {
                    Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    //if (direction.getDirection() == Direction.up)
                    //{
                    //    x += Height / 2;
                    //}
                    direction.increment();
                }
                Width = Height;
                Height = temp;

                //KeyValuePair<int, int> posFinal = getTrunkPosition();
                Top = y - (Height / 2);
                Left = x - (Width / 2);
            }
        }

        public void move(Image trail)
        {
            
        }

        public KeyValuePair<int, int> getPosition()
        {
            KeyValuePair<int, int> result = new KeyValuePair<int, int>(Left + Width / 2, Top + Height / 2);
            return result;
        }

        public KeyValuePair<int, int> getTrunkPosition()
        {
            int trunkx = Left + Width / 2;
            int trunky = 0;
            
            switch(direction.getDirection())
            {
                //case(Direction.left):
                //    trunkx = Left + Width;
                //    break;
                //case(Direction.right):
                //    trunkx = 
                //    break;
                case(Direction.up):
                    trunky = Top+Height;

                    break;
                case(Direction.down):
                    trunky = Top;
                    break;
                default:
                    trunky = (int)(Top + (float)Height / 2 + .5);
                    break;
            }
            KeyValuePair<int, int> result = new KeyValuePair<int, int>(trunkx, trunky);
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
