using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using BowlingGame.NET;

namespace BowlingGame.NETTests
{
    [TestClass()]
    public class GameTests
    {
        private readonly Game _game = new GameFactory().Create();

        private void RollPins(int times, int pins)
        {
            Enumerable.Range(1, times).ToList().ForEach((index) => _game.Roll(pins)); ;
        }

        [TestMethod()]
        public void RollTest_allZero()
        {
            RollPins(20, 0);
            Assert.AreEqual(0, _game.Score());
        }

        [TestMethod()]
        public void RollTest_allOne()
        {
            RollPins(20, 1);
            Assert.AreEqual(20, _game.Score());
        }

        [TestMethod()]
        public void RollTest_oneSpare()
        {
            RollSpare();
            _game.Roll(3);
            RollPins(17, 0);
            Assert.AreEqual(16, _game.Score());
        }     

        [TestMethod()]
        public void RollTest_oneStrike()
        {
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollPins(16, 0);
            Assert.AreEqual(24, _game.Score());
        }

        [TestMethod()]
        public void RollTest_PerfectGame()
        {
            RollPins(12,10);
            Assert.AreEqual(300, _game.Score());
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

    }
}