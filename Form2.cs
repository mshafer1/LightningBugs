using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightningBugs
{
    public partial class Form2 : Form
    {
        public Form2(List<Direction> options)
        {
            InitializeComponent();
            this.options = options;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = options;
        }
        private List<Direction> options;
    }
}
