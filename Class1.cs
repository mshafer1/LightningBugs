using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LightningBugs
{
    public class Class1 : Form1
    {
        public static bool vComputer;
        public static bool startClick;
        //public static bool pauseButton;
        //public static bool newGameButton;
        
        public Class1()
        {
            
        //    //this.button1.Visible = startClick;
        //    //this.button2.Visible = pauseButton;
        //    //this.button3.Visible = newGameButton;
        //    //this.button2.Visible = true;
            ((System.Windows.Forms.Control)(this.button2)).Visible = true;
            
        }

        //public static void doS()
        //{
        //    Class1 temp = new Class1();
        //    temp.doSomething();
           

        //}

        //public void doSomething()
        //{
        //    button2.Visible = true;
        //}
        
        
        //button1.Visible = true;
        public bool pauseButtonVisible
        {
            get { return button2.Visible; }
            set { button2.Visible = false; }
        }
        
        
    }
}
