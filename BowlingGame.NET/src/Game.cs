using System.Linq;

namespace BowlingGame.NET
{
    public class Game
    {
        private readonly Frame[] _frames;
        private int _currentFrameIndex;

        public Game(Frame[] frames)
        {
            this._frames = frames;
            this._currentFrameIndex = 0;
        }

        public bool Roll(int pins)
        {
            if (IsFinished()) return false;

            _frames[_currentFrameIndex].Roll(pins);
            if (_frames[_currentFrameIndex].IsFrameFinished())
            {                
                _currentFrameIndex++;
            }
            return true;
        }

        public bool IsFinished()
        {
            return _currentFrameIndex >= _frames.Length;
        }

        public int Score()
        {
            return _frames.Sum(frame => {
                System.Diagnostics.Debug.WriteLine("score: " + frame.GetScore());
                return frame.GetScore();
                });
        }

    }
}
