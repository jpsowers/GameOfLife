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

        public byte[] DrawGrid(int numberOfHorizontalRows, int numberOfVerticalRows, int lengthOfSideInPixels)
        {
            int totalHorzontalWidth = _populatedGrid.GetUpperBound(0)*lengthOfSideInPixels;
            int totalVerticalHeight = _populatedGrid.GetUpperBound(1)*lengthOfSideInPixels;

            using (var bitmap = new Bitmap(totalHorzontalWidth, totalVerticalHeight))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Red);
                    
                    var pen = new Pen(Color.Black) { Width = 1 };
                    //horizontals
                    for (int i = 1; i <= numberOfHorizontalRows -1; i++)
                    {
                        graphics.DrawLine(pen, new Point(0, totalVerticalHeight / numberOfHorizontalRows * i), 
                            new Point(totalHorzontalWidth, totalVerticalHeight / numberOfHorizontalRows * i));
                    }
                    //verticals
                    for (int i = 1; i <= numberOfVerticalRows -1; i++)
                    {
                        graphics.DrawLine(pen, new Point(totalHorzontalWidth / numberOfVerticalRows *i, 0), 
                            new Point(totalHorzontalWidth / numberOfVerticalRows*i, totalHorzontalWidth));
                      
                    }
                   
                }

                var memoryStream = new MemoryStream();

                bitmap.Save(memoryStream, ImageFormat.Jpeg);

                File.WriteAllBytes(@"c:\temp\testimage.jpg", memoryStream.ToArray());

                return memoryStream.ToArray();
            }
        }
    }
}