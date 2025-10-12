using SnakeGame.model;
using SnakeGame.model.actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.UI
{
    public class Controller
    {
        private Player _player;
        private Position2d _direction;
        private bool _run;
        public int keys = 0;

        private static Dictionary<ConsoleKey, Position2d> Directions = new Dictionary<ConsoleKey, Position2d>()
        {
            {ConsoleKey.UpArrow, new Position2d(0,-1) },
            {ConsoleKey.DownArrow, new Position2d(0,1) },
            {ConsoleKey.RightArrow, new Position2d(1,0) },
            {ConsoleKey.LeftArrow, new Position2d(-1,0) },
        };

        public Controller(Player player)
        {
            _player = player;
            _direction = new Position2d(1, 0);
        }

        public void Read()
        {
            if (!Console.KeyAvailable)
            {
                keys = 0;
                return;
            }

            ConsoleKey key = Console.ReadKey(true).Key;
            keys++;

            if (keys > 1)
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
                keys = 0;
            }


            switch (key)
            {
                case ConsoleKey.Escape:
                    _player.Alive = false;
                    break;
                default:
                    if (Directions.TryGetValue(key, out Position2d pos))
                    {
                        _direction = pos;
                    }
                    break;
            }

        }

        public void MovePlayer()
        {
            _player.Move(_player.Position + _direction);
        }
    }
}

