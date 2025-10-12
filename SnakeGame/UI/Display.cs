using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.UI
{
    public static class Display
    {

        public static void ResetWindow(int width, int heigth)
        {
            if (Console.WindowWidth != width || Console.WindowHeight != heigth)
            {
                Console.SetWindowSize(width, heigth);
                Console.SetBufferSize(width, heigth);
                Console.CursorVisible = false;
            }
        }

        public static void Draw(int x, int y, char ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }

        public static void Clear(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }
    }
}
