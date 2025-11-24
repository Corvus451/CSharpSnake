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
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.CursorVisible = false;
                Console.Title = "Snake Game";
            }
        }

        public static void Draw(int x, int y, char ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
        }

        public static void Write(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        public static void Clear(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        internal static void clearWindow()
        {
            Console.Clear();
        }
    }
}
