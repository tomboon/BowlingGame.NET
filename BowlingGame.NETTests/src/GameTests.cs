using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BowlingGame.NET.src.Tests
{
    [TestClass()]
    public class GameTests
    {
        private Game game;

        [TestInitialize()]
        public void before()
        {
            game = new GameFactory().create();
        }

        private void rollPins(int times, int pins)
        {
            Enumerable.Range(1, times).ToList().ForEach((index) => game.Roll(pins)); ;
        }

        [TestMethod()]
        public void rollTest_allZero()
        {
            rollPins(20, 0);
            Assert.AreEqual(0, game.Score());
        }

        [TestMethod()]
        public void rollTest_allOne()
        {
            rollPins(20, 1);
            Assert.AreEqual(20, game.Score());
        }

        [TestMethod()]
        public void rollTest_oneSpare()
        {
            RollSpare();
            game.Roll(3);
            rollPins(17, 0);
            Assert.AreEqual(16, game.Score());
        }     

        [TestMethod()]
        public void rollTest_oneStrike()
        {
            rollStrike(); // strike
            game.Roll(3);
            game.Roll(4);
            rollPins(16, 0);
            Assert.AreEqual(24, game.Score());
        }

        [TestMethod()]
        public void rollTest_PerfectGame()
        {
            rollPins(12,10);
            Assert.AreEqual(300, game.Score());
        }

        private void rollStrike()
        {
            game.Roll(10);
        }

        private void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

    }
}