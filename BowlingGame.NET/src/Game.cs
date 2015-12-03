using System.Linq;

namespace BowlingGame.NET.src
{
    public class Game
    {
        private Frame[] frames = new Frame[20];
        private int currentFrameIndex;

        internal Game(Frame[] frames)
        {
            this.frames = frames;
            this.currentFrameIndex = 0;
        }

        public bool Roll(int pins)
        {
            if (IsFinished()) return false;

            frames[currentFrameIndex].Roll(pins);
            if (frames[currentFrameIndex].IsFrameFinished())
            {                
                currentFrameIndex++;
            }
            return true;
        }

        public bool IsFinished()
        {
            return currentFrameIndex >= frames.Length;
        }

        public int Score()
        {
            return frames.Sum(frame => {
                System.Diagnostics.Debug.WriteLine("score: " + frame.GetScore());
                return frame.GetScore();
                });
        }

    }
}
