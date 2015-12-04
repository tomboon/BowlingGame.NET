using BowlingGame.NET;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BowlingGame.NETTests
{
    [TestClass()]
    public class ProgramTests
    {
        private GameFactory _gameFactory;
        private Game _game;
        private Frame _frame;

        [TestInitialize()]
        public void Initalize()
        {
            _frame = new Frame(null);
            _game = new Game(new Frame[] { _frame });
            _gameFactory = Mock.Of<GameFactory>(factory => factory.Create() == _game);
            //TODO !!! method must be virtual to be able to mock (or should mock an interface!?)
        }
        
        [TestMethod()]
        public void ProgramTest()
        {
            var program = new Program(_gameFactory);
            program.Run();

            Assert.AreEqual(2, program.FinalScore());
        }

    

    }
}