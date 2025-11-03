using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.model.actors
{
    public class Player : Actor
    {
        public bool Alive;
        private Tail _tail;

        public Player(Position2d position, Board board) : base(position, '@', board)
        {
            Alive = true;
        }

        public void AddTail()
        {
            Tail current = _tail;

            if (current == null)
            {
                _tail = new Tail(LastPosition, _board);
                _board.AddActor(_tail);
                return;
            }


            while (current.nextTail != null)
            {
                current = current.nextTail;
            }
            current.nextTail = new Tail(current.LastPosition, _board);
            _board.AddActor(current.nextTail);
        }

        public override bool Move(Position2d newPosition)
        {
            //return base.Move(newPosition);
            if (base.Move(newPosition))
            {
                _tail?.Move(LastPosition);
                return true;
            }

            return false;
        }

        public void End()
        {
            Alive = false;
        }
    }

    public class Tail : Actor
    {
        public Tail nextTail;

        public Tail(Position2d position, Board board) : base(position, '#', board)
        {

        }

        public override bool Move(Position2d newPosition)
        {
            base.Move(newPosition);
            nextTail?.Move(LastPosition);
            return true;
        }

        public override bool Touch(Actor source)
        {
            if (source is Player player)
            {
                player.End();
            }
            return true;
        }
    }
}
