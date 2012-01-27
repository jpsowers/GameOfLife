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

        public byte[] DrawGrid(int height, int width)
        {
            int horizontalPartitions = _populatedGrid.GetUpperBound(0)*100;
            int verticalPartitions = _populatedGrid.GetUpperBound(1)*100;

            using (var bitmap = new Bitmap(horizontalPartitions, verticalPartitions))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Red);
                    
                    var pen = new Pen(Color.Black) { Width = 1 };
                    
                    //for (int i = 0; i < height -1; i++)
                    //{
                    //horizontals
                        graphics.DrawLine(pen, new Point(0, verticalPartitions /3), new Point(horizontalPartitions, verticalPartitions /3)); 
                        graphics.DrawLine(pen, new Point(0, verticalPartitions /3 * 2), new Point(horizontalPartitions, verticalPartitions /3 * 2)); 
                     //veritcals  
                        graphics.DrawLine(pen, new Point(verticalPartitions /3 , 0), new Point( verticalPartitions /3 , horizontalPartitions));
                        graphics.DrawLine(pen, new Point(verticalPartitions / 3 * 2, 0), new Point(verticalPartitions / 3 * 2, horizontalPartitions)); 
                    //}
                    

                   
                }

                var memoryStream = new MemoryStream();

                bitmap.Save(memoryStream, ImageFormat.Jpeg);

                File.WriteAllBytes(@"c:\temp\testimage.jpg", memoryStream.ToArray());

                return memoryStream.ToArray();
            }
        }
    }
}