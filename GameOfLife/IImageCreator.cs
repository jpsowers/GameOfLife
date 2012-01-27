namespace GameOfLife
{
    public interface IImageCreator
    {
        byte[] DrawGrid(int numberOfHorizontalRows, int numberOfVerticalRows, int lengthOfSideInPixels);
    }
}