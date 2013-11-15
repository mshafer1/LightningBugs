using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightningBugs
{
    public enum Direction
    {
        right,
        up,
        left,
        down
    };
    public class DrirectionClass: IComparable<Direction>
    {
        Direction direction;
        public DrirectionClass()
        {
            direction = Direction.up;
        }
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
            else
            {
                direction = Direction.down;
            }
        }
        public int CompareTo(Direction p)
        {
            int result = 0;
            if (p < direction)
            {
                result--;
            }
            else if (p > direction)
            {
                result++;
            }
            return result;
        }
    }
}
