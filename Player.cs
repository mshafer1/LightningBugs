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
            {
                int temp = Width;
                int x = (int)(Left + (float)Width / 2 + .5);
                int y = (int)(Top + (float)Height/2+.5);
                
                if (direction.CompareTo(d) < 0)
                {
                    Image.RotateFlip(RotateFlipType.Rotate270FlipXY);
                    direction.decrement();
                }
                else
                {
                    Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
                    direction.increment();
                }
                
                Width = Height;
                Height = temp;

                Top = y - (int)((float)Height / 2 + .5);
                Left = x - (int)((float)Width / 2 + .5);
            }
        }

        public void move()
        {

        }

        public KeyValuePair<int, int> getPosition()
        {
            KeyValuePair<int, int> result = new KeyValuePair<int, int>(Left + Width / 2, Top - Height / 2);
            return result;
        }

        private DrirectionClass direction;
    }
}
