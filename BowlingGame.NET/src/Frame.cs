using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.NET
{
    internal class Frame
    {
        private readonly Frame _nextFrame;
        protected List<Roll> Rolls { get; } = new List<Roll>();

        internal Frame(Frame nextFrame)
        {
            this._nextFrame = nextFrame;
        }
        
        internal void Roll(int pins)
        {
            if (IsFrameFinished()) throw new IndexOutOfRangeException("Frame is already finished");
            Rolls.Add(new Roll(pins));
        }

        internal virtual bool IsFrameFinished()
        {
            return IsStrike() || 2 == Rolls.Count();
        }

        internal bool IsSpare()
        {
            return 10 == (Rolls.ElementAtOrDefault(0)?.Pins ?? 0) + (Rolls.ElementAtOrDefault(1)?.Pins ?? 0);
        }

        internal bool IsStrike()
        {
            return Rolls.FirstOrDefault()?.IsStrike() ?? false;
        }

        internal virtual int GetScore()
        {
            if (IsStrike())
                return GetNumberOfPinsInThisFrame() + _nextFrame.GetStrikeBonusForPreviousFrame();

            if (IsSpare())
                return GetNumberOfPinsInThisFrame() + _nextFrame.GetSpareBonusForPreviousFrame();
            
            return GetNumberOfPinsInThisFrame();
        }

        internal int GetNumberOfPinsInThisFrame()
        {
            return Rolls.Sum(roll => roll.Pins);
        }

        internal int GetSpareBonusForPreviousFrame()
        {
            return GetNumberOfPinsOfFirstRoll();
        }

        internal virtual int GetStrikeBonusForPreviousFrame()
        {
            if (IsStrike())
            {
                return GetNumberOfPinsInThisFrame() + _nextFrame.GetNumberOfPinsOfFirstRoll();
            }
            return GetNumberOfPinsInThisFrame();
        }

        internal int GetNumberOfPinsOfFirstRoll()
        {
            return Rolls.ElementAt(0)?.Pins ?? 0;
        }


    }
}
