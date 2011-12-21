using System;

namespace GameOfLife
{
   public class Game
    {
       public Game()
       {
           Grid = new string[3,3];
           PopulateInitialGrid();
       }

       public string Start()
       {
           return "Started";
       }

       public string[,] Grid { get; set; }

      public void PopulateInitialGrid()
      {
          Grid[0, 0] = "0";
          Grid[0, 1] = "0";
          Grid[0, 2] = "0";
          Grid[1, 0] = "X";
          Grid[1, 1] = "X";
          Grid[1, 2] = "0";
          Grid[2, 0] = "0";
          Grid[2, 1] = "0";
          Grid[2, 2] = "0";
      }
    }
}
