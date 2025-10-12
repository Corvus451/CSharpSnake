using SnakeGame.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.model.actors
{
    public abstract class Actor
    {
        public Position2d Position;
        public Position2d LastPosition;
        public char Appearance;
        private Position2d _nextPosition;
        protected Board _board;

        public Actor(Position2d position, char appearance, Board board)
        {
            Position = position;
            Appearance = appearance;
            _board = board;
        }

        public virtual bool Move(Position2d newPosition)
        {

            _nextPosition = newPosition;

            if (!_board.ValidCell(_nextPosition))
            {
                return false;
            }

            if (_board.CheckCell(_nextPosition, out Actor found))
            {
                if (!found.Touch(this))
                {
                    return false;
                }
            }

            _board.ClearCell(Position);
            LastPosition = Position;
            Position = _nextPosition;
            _board.SetCell(Position, Appearance);
            return true;
        }

        public void setNextPosition(Position2d newPosition)
        {
            _nextPosition = newPosition;
        }

        public virtual bool Touch(Actor source)
        {
            return false;
        }
    }
}
