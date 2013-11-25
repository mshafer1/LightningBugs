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
    public partial class GameImage : PictureBox
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
    }
}
