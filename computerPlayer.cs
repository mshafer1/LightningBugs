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
        public computerPlayer(Image image): base(image)
        {
        }

        public override void turn(Direction d)
        {
            while (direction.CompareTo(d) != 0)
            {
                int temp = Width;

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
    }
}
