namespace GameOfLife
{
    public interface IImageCreator
    {
        byte[] DrawGrid(Grid grid);
    }
}