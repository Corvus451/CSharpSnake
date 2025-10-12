using SnakeGame.model;
using SnakeGame.model.actors;
using SnakeGame.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Game
    {
        private int _width;
        private int _height;
        private Board _board;
        private Controller _controller;
        private Player _player;
        private bool _run;
        private int _time;


        public Game(int width = 30, int height = 15, int time = 100)
        {
            _width = width;
            _height = height;
            _board = new Board(width, height);
            _time = time;
        }

        public void Setup()
        {
            Display.ResetWindow(_width, _height);
            Display.clearWindow();
            _player = new Player(new Position2d(5, 5), _board);
            _board.AddActor(_player);
            _controller = new Controller(_player);
            _run = true;
        }

        public void Run()
        {

            Setup();

            while (_run)
            {

                _controller.Read();
                _controller.MovePlayer();

                _run = _player.Alive;
                Thread.Sleep(_time);
                Display.ResetWindow(_width, _height);
            }

            Console.Clear();
            Console.SetCursorPosition(_width / 2, _height / 2);
            Console.Write("GAME OVER");
            Console.ReadKey();
        }
    }
}
