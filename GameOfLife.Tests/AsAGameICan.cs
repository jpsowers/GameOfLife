using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class AsAGameICan
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }

        [Test]
        public void ReturnAString()
        {
            string result = _game.Start();
            Assert.That(!string.IsNullOrWhiteSpace(result));
        }

        [Test]
        public void HasAGridWithAtLeastNineSquares()
        {
            var count = _game.Grid.Length;
            Assert.That(9, Is.EqualTo(count));
        }

        [Test]
        public void AtLeastOneValueOfTheArrayIsAnX()
        {
            var thereIsAnX = 0;

            for (var i = 0; i < _game.Grid.GetUpperBound(1); i++)
            {
                for (var j = 0; j < _game.Grid.GetUpperBound(0); j++)
                {
                    if(_game.Grid[i,j] == "X")
                    {
                        thereIsAnX = thereIsAnX + 1;
                    }
                }
            }
            Assert.That(thereIsAnX > 0);
        }

        [Test]
        public void TellWhenTwoValuesOfTheArrayAreX()
        {
            var thereIsAnX = 0;

            for (var i = 0; i < _game.Grid.GetUpperBound(1); i++)
            {
                for (var j = 0; j < _game.Grid.GetUpperBound(0); j++)
                {
                    if(_game.Grid[i,j] == "X")
                    {
                        thereIsAnX = thereIsAnX + 1;
                    }
                }
            }
            Assert.That(2, Is.EqualTo(thereIsAnX));
        }


    }
}