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
    public partial class NewGameScreen : UserControl
    {
        public NewGameScreen()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private bool start;
        public bool Start
        {
            get { return this.start; }
            set { this.start = value; }
        }

        public event EventHandler StartGameTime;

        private void btnStart_Click(object sender, EventArgs e)
        {
            start = true;
            OnStartGameEvent(e);
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            start = false;
        }

        public delegate void StartGameEventHandler(object sender, EventArgs e);

        public void OnStartGameEvent(EventArgs e)
        {
            EventHandler handler = StartGameTime;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
