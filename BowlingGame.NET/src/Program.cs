using System;
using System.Linq;

namespace BowlingGame.NET
{
    public class Program
    {

        private readonly Game _game;

        public static void Main(string[] args)
        {
            Console.WriteLine("Hello bowling _game");
        }

        public Program(GameFactory gameFactory)
        {
            _game = gameFactory.Create();
        }

        public void Run()
        {
            Enumerable.Range(1, 20).ToList().ForEach((index) => _game.Roll(1));
        }

        public int FinalScore()
        {
            return _game.Score();
        }
    }
}
