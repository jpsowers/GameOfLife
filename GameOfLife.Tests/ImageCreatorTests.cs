using System.IO;
using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class ImageCreatorTests
    {
        private IImageCreator _imageCreator;

        [SetUp]
        public void SetUp()
        {
            if (!Directory.Exists(@"c:\temp"))
            {
                Directory.CreateDirectory(@"c:\temp");
            }
            _imageCreator = new ImageCreator(ThreeByThreeTestGrid());
        }

        [Test]
        public void CreateAJpg()
        {
            _imageCreator.DrawGrid(25, 25, 200);
            Assert.That(true, Is.EqualTo(File.Exists(@"c:\temp\testimage.jpg")));
        }

        public string[,] ThreeByThreeTestGrid()
        {
            var grid = new string[3,3];
            grid[0, 0] = "0";
            grid[0, 1] = "X";
            grid[0, 2] = "0";
            grid[1, 0] = "X";
            grid[1, 1] = "X";
            grid[1, 2] = "0";
            grid[2, 0] = "0";
            grid[2, 1] = "0";
            grid[2, 2] = "0";
            return grid;
        }
    }
}