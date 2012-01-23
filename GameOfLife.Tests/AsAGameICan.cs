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
            int thereIsAnX = _game.CountOfXValuesOnGrid();
            Assert.That(thereIsAnX > 0);
        }

        [Test]
        public void ReturnThreeWhenThereAreThreeXsOnTheGrid()
        {
            int thereIsAnX = _game.CountOfXValuesOnGrid();
            Assert.That(3, Is.EqualTo(thereIsAnX));
        }

        [Test]
        public void CanCalculateHowManyXsAreAroundTheCenterSquareOfA3X3Grid()
        {
           Assert.AreEqual(2, _game.CountOfXValuesAdjacentToCenterOfGrid());
        }

        [Test]
        public void CanCalculateHowManyXsAreAroundALocationPassedInAssumingNullsForLocationsOfftheGrid()
        {
            Assert.That(2, Is.EqualTo(_game.CountOfValuesAdjacentToLocation(new Cell(1,0))));
        }
       
        [Test]
        public void CalculateTheNextValueForALocationPassedIn()
        {
            var celltoLive = new Cell(0,0);
            var cellToDie = new Cell(2,0);
            Assert.That("X", Is.EqualTo(_game.ValueAtNextGeneration(celltoLive)));
            Assert.That("0", Is.EqualTo( _game.ValueAtNextGeneration(cellToDie)));
        }

   
    }
}