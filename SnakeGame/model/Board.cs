using SnakeGame.model.actors;
using SnakeGame.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.model
{
    public class Board
    {
        private readonly int _width;
        private readonly int _height;
        private List<Actor> _actors;
        private Random _random = new();
        private int score = 0;
        //private Actor[,] _surface;

        public Board(int width, int height)
        {
            _width = width;
            _height = height;
            _actors = new List<Actor>();
            //_surface = new Actor[_width, _height];
        }

        public bool ValidCell(Position2d position)
        {
            return position.X < _width && position.X >= 0 && position.Y < _height && position.Y >= 0;
        }

        public void SetCell(Position2d position, char ch)
        {
            Display.Draw(position.X, position.Y, ch);
        }

        public void ClearCell(Position2d position)
        {
            Display.Clear(position.X, position.Y);
        }

        public bool IsEmptyCell(Position2d pos)
        {
            return !_actors.Any((a) => a.Position == pos);
        }

        public bool CheckCell(Position2d position, out Actor found)
        {
            found = _actors.Find((a) => a.Position == position);
            return found != null;
        }

        public bool AddActor(Actor actor)
        {
            if (!IsEmptyCell(actor.Position))
            {
                return false;
            }
            _actors.Add(actor);
            SetCell(actor.Position, actor.Appearance);
            return true;
        }

        public void RemoveActor(Actor actor)
        {
            ClearCell(actor.Position);
            _actors.Remove(actor);
        }

        public Position2d GetRandomEmptyCell()
        {
            Position2d position;
            int X, Y;

            for (int i = 0; i < 300; i++)
            {
                X = _random.Next(_width);
                Y = _random.Next(_height);
                position = new Position2d(X, Y);

                if (IsEmptyCell(position))
                {
                    return position;
                }
            }
            return null;
        }
    }
}
