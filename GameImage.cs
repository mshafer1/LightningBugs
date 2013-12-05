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
    public partial class GameImage : PictureBox , IComparable<GameImage>
    {
        public GameImage(Image gameImage)
        {
            InitializeComponent();
            Image =  gameImage;
            Size = new System.Drawing.Size(gameImage.Width, gameImage.Height);
            SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            TabStop = false;
        }

        public KeyValuePair<int, int> centerPos()
        {
            KeyValuePair<int, int> result = new KeyValuePair<int, int>(Left + Width / 2, Top + Height / 2);
            return result;
        }

        //this function is necessary for == or < or > comparisons, it returns 0 for =, -1 for less than, and 1 for greater than
        public int CompareTo(GameImage p)
        {
            KeyValuePair<int, int> pos = centerPos();
            int myPos = pos.Key + pos.Value;
            int threshold = 6;
            int result = 0;

            int temp = p.centerPos().Key;
            temp = p.centerPos().Value;
            int pPos = p.centerPos().Key + p.centerPos().Value;

            if (((Left <= p.Right - threshold && Right >= p.Left + threshold) && (Top <= p.Bottom - threshold && Bottom >= p.Top + threshold)))
            {
                result = 0;
            }
            else
            {
                if (myPos > pPos)
                {
                    result++;
                }
                else
                {
                    result--;
                }
            }
            return result;
        }
    }
}
