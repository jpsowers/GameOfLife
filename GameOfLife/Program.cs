using System;

namespace GameOfLife
{
    class Program
    {
        
        static  void Main(string[] args)
        {
            var game = new Game();
            Console.WriteLine(game.Start());
            Console.ReadKey();
        }

  
    }
}
