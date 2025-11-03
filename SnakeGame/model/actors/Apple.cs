using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.model.actors
{
    public class Apple : Actor
    {
        public Apple(Position2d position, Board board) : base(position, '@', board)
        {
        }

        public override bool Touch(Actor source)
        {
            if (source is Player player)
            {
                player.AddTail();
                //_board.AddNewApple();
                //_board.RemoveActor(this);
                Position2d newPos = _board.GetRandomEmptyCell();
                base.Move(newPos);
            }
            return true;
        }
    }
}
