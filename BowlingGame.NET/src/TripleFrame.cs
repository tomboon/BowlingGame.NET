using System.Linq;

namespace BowlingGame.NET
{
    public class TripleFrame : Frame
    {
        internal TripleFrame() : base(null) { }
        
        public override bool IsFrameFinished()
        {   
            if (IsStrike() || IsSpare())
            {
                return Rolls.Count() == 3;
            }
            return base.Rolls.Count() == 2;
        }

        public override int GetScore()
        {
            return GetNumberOfPinsInThisFrame();
        }

        protected override int GetStrikeBonusForPreviousFrame()
        {
            return (Rolls.ElementAtOrDefault(0)?.Pins ?? 0) + (Rolls.ElementAtOrDefault(1)?.Pins ?? 0);
        }
    }
}
