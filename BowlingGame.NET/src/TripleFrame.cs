using System.Linq;

namespace BowlingGame.NET.src
{
    internal class TripleFrame : Frame
    {
        internal TripleFrame() : base(null) { }
        
        public override bool IsFrameFinished()
        {   
            if (IsStrike() || IsSpare())
            {
                return base.Rolls.Count() == 3;
            }
            return base.Rolls.Count() == 2;
        }

        public override int GetScore()
        {
            return GetNumberOfPinsInThisFrame();
        }

        protected override int GetStrikeBonusForPreviousFrame()
        {
            return (Rolls.ElementAtOrDefault(0)?.pins ?? 0) + (Rolls.ElementAtOrDefault(1)?.pins ?? 0);
        }
    }
}
