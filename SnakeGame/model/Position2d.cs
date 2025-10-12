using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.model
{
    public record Position2d(int X, int Y)
    {
        public static Position2d operator +(Position2d a, Position2d b)
        {
            return new Position2d(a.X + b.X, a.Y + b.Y);
        }

        public static Position2d operator -(Position2d a, Position2d b)
        {
            return new Position2d(a.X - b.X, a.Y - b.Y);
        }
    }
}
