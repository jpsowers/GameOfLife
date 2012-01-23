namespace GameOfLife
{
    public static class ExtensionMethods
    {
        private const string DeadCell = "0";
        private const string LiveCell = "X";

        public static bool IsAliveInThis(this Cell cell, string[,] grid)
        {
            return grid[cell.X, cell.Y] == LiveCell;
        }

        public static bool IsDeadInThis(this Cell cell, string[,] grid)
        {
            return grid[cell.X, cell.Y] == DeadCell;
        }

        public static bool ShouldLiveOnWithThisNumberOfNeighbors(this Cell cell, int numberOfNeighbors)
        {
            return(numberOfNeighbors == 2 || numberOfNeighbors == 3);
        }

    }
}