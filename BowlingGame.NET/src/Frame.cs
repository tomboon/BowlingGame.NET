using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.NET.src
{
    internal class Frame
    {
        private Frame NextFrame;
        protected List<Roll> Rolls { get; } = new List<Roll>();

        internal Frame(Frame nextFrame)
        {
            this.NextFrame = nextFrame;
        }
        
        public void Roll(int pins)
        {
            if (IsFrameFinished()) throw new IndexOutOfRangeException("Frame is already finished");
            Rolls.Add(new Roll(pins));
        }

        public virtual bool IsFrameFinished()
        {
            return IsStrike() || 2 == Rolls.Count();
        }
                
        public bool IsSpare()
        {
            return 10 == (Rolls.ElementAtOrDefault(0)?.pins ?? 0) + (Rolls.ElementAtOrDefault(1)?.pins ?? 0);
        }

        public bool IsStrike()
        {
            return Rolls.FirstOrDefault()?.IsStrike() ?? false;
        }

        public virtual int GetScore()
        {
            if (IsStrike())
                return GetNumberOfPinsInThisFrame() + NextFrame.GetStrikeBonusForPreviousFrame();

            if (IsSpare())
                return GetNumberOfPinsInThisFrame() + NextFrame.GetSpareBonusForPreviousFrame();
            
            return GetNumberOfPinsInThisFrame();
        }

        public int GetNumberOfPinsInThisFrame()
        {
            return Rolls.Sum(roll => roll.pins);
        }

        private int GetSpareBonusForPreviousFrame()
        {
            return GetNumberOfPinsOfFirstRoll();
        }

        protected virtual int GetStrikeBonusForPreviousFrame()
        {
            if (IsStrike())
            {
                return GetNumberOfPinsInThisFrame() + NextFrame.GetNumberOfPinsOfFirstRoll();
            }
            return GetNumberOfPinsInThisFrame();
        }     

        private int GetNumberOfPinsOfFirstRoll()
        {
            return Rolls.ElementAt(0)?.pins ?? 0;
        }


    }
}
