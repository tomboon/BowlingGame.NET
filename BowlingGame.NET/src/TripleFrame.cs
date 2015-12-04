using System.Linq;

namespace BowlingGame.NET
{
    internal class TripleFrame : Frame
    {
        internal TripleFrame() : base(null) { }

        internal override bool IsFrameFinished()
        {   
            if (IsStrike() || IsSpare())
            {
                return Rolls.Count() == 3;
            }
            return base.Rolls.Count() == 2;
        }

        internal override int GetScore()
        {
            return GetNumberOfPinsInThisFrame();
        }

        internal override int GetStrikeBonusForPreviousFrame()
        {
            return (Rolls.ElementAtOrDefault(0)?.Pins ?? 0) + (Rolls.ElementAtOrDefault(1)?.Pins ?? 0);
        }
    }
}
