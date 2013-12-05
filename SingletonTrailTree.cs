﻿using System;
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
            if(trails == null || check)
            {
                trails = new AVLTree<GameImage>();
            }
            return trails;
        }

        //private static SingletonTrailTree instance;
        public static AVLTree<GameImage> trails;
    }
}
