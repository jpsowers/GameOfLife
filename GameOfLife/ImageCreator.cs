using System;
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

        public byte[] DrawGrid(Grid grid)
        {
            int totalHorzontalWidth = _populatedGrid.GetUpperBound(0)*grid.LengthOfSideInPixels;
            int totalVerticalHeight = _populatedGrid.GetUpperBound(1)*grid.LengthOfSideInPixels;

            using (var bitmap = new Bitmap(totalHorzontalWidth, totalVerticalHeight))
            {
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Red);

                    var pen = new Pen(Color.Black) {Width = 1};
                    //horizontals
                    for (int i = 1; i <= grid.NumberOfHorizontalRows - 1; i++)
                    {
                        graphics.DrawLine(pen, new Point(0, totalVerticalHeight/grid.NumberOfHorizontalRows*i),
                                          new Point(totalHorzontalWidth, totalVerticalHeight/grid.NumberOfHorizontalRows*i));
                    }
                    //verticals
                    for (int i = 1; i <= grid.NumberOfVerticalRows - 1; i++)
                    {
                        graphics.DrawLine(pen, new Point(totalHorzontalWidth/grid.NumberOfVerticalRows*i, 0),
                                          new Point(totalHorzontalWidth/grid.NumberOfVerticalRows*i, totalHorzontalWidth));
                    }
                }
                Bitmap niftyNewBitmap = PopulateGridSquaresBasedOnTheNiftyArray(bitmap);

                var memoryStream = new MemoryStream();

                niftyNewBitmap.Save(memoryStream, ImageFormat.Jpeg);
                bitmap.Save(memoryStream, ImageFormat.Jpeg);

                File.WriteAllBytes(@"c:\temp\testimage.jpg", memoryStream.ToArray());

                return memoryStream.ToArray();
            }
        }

        public Bitmap PopulateGridSquaresBasedOnTheNiftyArray(Bitmap theBitmap)
        {
            return theBitmap;
        }
    }
}