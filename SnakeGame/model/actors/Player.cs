using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.model.actors
{
    class Player : Actor
    {
        public bool Alive;

        public Player(Position2d position, Board board) : base(position, '@', board)
        {
            Alive = true;
        }

        public void End()
        {
            Alive = false;
        }
    }
}
