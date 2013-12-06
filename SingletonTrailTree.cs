using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfBalancedTree;

namespace LightningBugs
{
    public static class SingletonTrailTree
    {
        static SingletonTrailTree() { }
        
        public static AVLTree<GameImage> getInstance(bool check = false)
        {
            if(trails == null)
            {
                trails = new AVLTree<GameImage>();
                
            }
            else if (check)
            {
                if (trails != null)
                {
                    trails.Clear();
                }
            }
            return trails;
        }

        //private static SingletonTrailTree instance;
        public static AVLTree<GameImage> trails;
    }
}
