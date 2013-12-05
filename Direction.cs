using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightningBugs
{
    //enumerated type for direction
    public enum Direction
    {
        right = 0,
        up = 1,
        left = 2,
        down = 3
    };

    //this class exists to allow increment and decrement to wrap around, and compare use defined way
    public class DrirectionClass : IComparable<Direction>
    {
        Direction direction;

        //default constructor - since car pictures are up to start
        public DrirectionClass()
        {
            direction = Direction.up;
        }

        //return the direction enumeration
        public Direction getDirection()
        {
            return direction;
        }

        public void increment()
        {
            if (direction != Direction.down)
            {
                direction++;
            }
            //once at the end of enum, jump back to beginning
            else
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
            //conversely, jump to back
            else
            {
                direction = Direction.down;
            }
        }

        //this function is necessary for == or < or > comparisons, it returns 0 for =, -1 for less than, and 1 for greater than
        public int CompareTo(Direction p)
        {
            int result = 0;
            if (p != direction)
            {
                result--;
                if (p > direction)
                {
                    result += 2;
                }
            }
            return result;
        }
    }
}
