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

        private void SomethingClicked(object sender, EventArgs e)
        {
            btnStart.Focus();
        }

        private void KeyPressEvent(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'p' || e.KeyChar == 'P')
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
            }
            else if (e.KeyChar == 'c' || e.KeyChar == 'C')
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else if (e.KeyChar == 'e' || e.KeyChar == 'E')
            {
                comboBox1.SelectedIndex = 0;
            }
            else if (e.KeyChar == 'm' || e.KeyChar == 'M')
            {
                comboBox1.SelectedIndex = 1;
            }
            else if (e.KeyChar == 'h' || e.KeyChar == 'H')
            {
                comboBox1.SelectedIndex = 2;
            }
        }
    }
}
