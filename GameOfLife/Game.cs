using System;

namespace GameOfLife
{
    public class Game
    {
        private const string DeadCell = "0";
        private const string LiveCell = "X";

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
            Grid[0, 1] = "X";
            Grid[0, 2] = "0";
            Grid[1, 0] = "X";
            Grid[1, 1] = "X";
            Grid[1, 2] = "0";
            Grid[2, 0] = "0";
            Grid[2, 1] = "0";
            Grid[2, 2] = "0";
        }

        public int CountOfXValuesOnGrid()
        {
            var countOfXValuesOnGrid = 0;

            for (var x = 0; x <= Grid.GetUpperBound(1); x++)
            {
                for (var y = 0; y <= Grid.GetUpperBound(0); y++)
                {
                    if (Grid[x, y] == "X")
                    {
                        countOfXValuesOnGrid = countOfXValuesOnGrid + 1;
                    }
                }
            }
            return countOfXValuesOnGrid;
        }

        public int CountOfXValuesAdjacentToCenterOfGrid()
        {
            return CountOfValuesAdjacentToLocation(new Cell(1,1));
        }

        public int CountOfValuesAdjacentToLocation(Cell cell)
        {
            var count = 0;
            if (LocationExistsInGrid(cell.X - 1, cell.Y - 1) && Grid[cell.X - 1, cell.Y - 1] == "X")
            {
                count++;
            }
            if (LocationExistsInGrid(cell.X - 1, cell.Y) && Grid[cell.X - 1, cell.Y] == "X")
            {
                count++;
            }
            if (LocationExistsInGrid(cell.X - 1, cell.Y + 1) && Grid[cell.X - 1, cell.Y + 1] == "X")
            {
                count++;
            }
            if (LocationExistsInGrid(cell.X + 1, cell.Y -1) && Grid[cell.X + 1, cell.Y -1] == "X")
            {
                count++;
            }
            if (LocationExistsInGrid(cell.X + 1, cell.Y) && Grid[cell.X + 1, cell.Y] == "X")
            {
                count++;
            }
            if (LocationExistsInGrid(cell.X + 1, cell.Y + 1) && Grid[cell.X + 1, cell.Y + 1] == "X")
            {
                count++;
            }
            if (LocationExistsInGrid(cell.X, cell.Y + 1) && Grid[cell.X, cell.Y + 1] == "X")
            {
                count++;
            }
            if (LocationExistsInGrid(cell.X, cell.Y -1) && Grid[cell.X, cell.Y -1] == "X")
            {
                count++;
            }

            return count;
        }

        private bool LocationExistsInGrid(int i, int j)
        {
            return i >= Grid.GetLowerBound(0) && i <= Grid.GetUpperBound(0)
                   && j >= Grid.GetLowerBound(1) && j <= Grid.GetUpperBound(1);
        }

        public string ValueAtNextGeneration(Cell cell)
        {
            var numberOfNeighbors = CountOfValuesAdjacentToLocation(cell);

            if (cell.IsAliveInThis(Grid) && HasTooFewOrTooManyNeighbors(numberOfNeighbors))
            {
                return DeadCell;
            }

            if (cell.IsAliveInThis(Grid) && cell.ShouldLiveOnWithThisNumberOfNeighbors(numberOfNeighbors))
            {
                return LiveCell;
            }

            if (cell.IsDeadInThis(Grid) && HasTooFewOrTooManyNeighbors(numberOfNeighbors))
            {
                return LiveCell;
            }
            
            return DeadCell;
        }

        public bool HasTooFewOrTooManyNeighbors(int numberOfNeighbors)
        {
            return  numberOfNeighbors < 2 || numberOfNeighbors >= 3;
        }

    }
}