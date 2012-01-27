namespace GameOfLife
{
    public interface IImageCreator
    {
        byte[] DrawGrid(int height, int width);
    }
}