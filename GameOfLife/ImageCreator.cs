using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace GameOfLife
{
    public class ImageCreator : IImageCreator
    {
        private readonly string[,] _populatedGrid;


        public ImageCreator(string[,] populatedGrid)
        {
            _populatedGrid = populatedGrid;
        }

        public byte[] DrawGrid()
        {
            
            using (var grid = new Bitmap(_populatedGrid.GetUpperBound(0), _populatedGrid.GetUpperBound(1)))
            {
                using (var graphics = Graphics.FromImage(grid))
                {
                    var pen = new Pen(Color.Black) {Width = 1};

                    graphics.DrawLine(pen,new Point(0,1),new Point(1,1));

                    graphics.Clear(Color.Red);
                }

                var memoryStream = new MemoryStream();

                grid.Save(memoryStream, ImageFormat.Jpeg);

                File.WriteAllBytes(@"c:\temp\testimage.jpg", memoryStream.ToArray());
               
                return memoryStream.ToArray();
            }
        }
    }
}