namespace SnakeGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(30, 15, 100);
            game.Run();
        }
    }
}
