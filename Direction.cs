using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LightningBugs
{
    public enum Direction//enumerated type for direction
    {
        right = 0,
        up = 1,
        left = 2,
        down = 3
    };
    public class DrirectionClass : IComparable<Direction>//this class exists to allow increment and decrement to wrap around, and compare use defined way
    {
        Direction direction;
        public DrirectionClass()//default constructor - since car pictures are up to start
        {
            direction = Direction.up;
        }
        public Direction getDirection()//return the direction enumeration
        {
            return direction;
        }
        public void increment()
        {
            if (direction != Direction.down)
            {
                direction++;
            }
            else//once at the end of enum, jump back to beginning
            {
                direction = Direction.right;
            }
        }
        public void decrement()
        {
            if (direction != Direction.right)
            {
                direction--;
            }
            else//conversely, jump to back
            {
                direction = Direction.down;
            }
        }
        public int CompareTo(Direction p)//this function is necessary for == or < or > comparisons, it returns 0 for =, -1 for less than, and 1 for greater than
        {
            int result = 0;
            if (p != direction)
            {
                result--;
                if (p > direction)
                {
                    result+=2;
                }
            }
            return result;
        }
    }
}
