using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.NET
{
    public class Frame
    {
        private readonly Frame _nextFrame;
        protected List<Roll> Rolls { get; } = new List<Roll>();

        public Frame(Frame nextFrame)
        {
            this._nextFrame = nextFrame;
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
            return 10 == (Rolls.ElementAtOrDefault(0)?.Pins ?? 0) + (Rolls.ElementAtOrDefault(1)?.Pins ?? 0);
        }

        public bool IsStrike()
        {
            return Rolls.FirstOrDefault()?.IsStrike() ?? false;
        }

        public virtual int GetScore()
        {
            if (IsStrike())
                return GetNumberOfPinsInThisFrame() + _nextFrame.GetStrikeBonusForPreviousFrame();

            if (IsSpare())
                return GetNumberOfPinsInThisFrame() + _nextFrame.GetSpareBonusForPreviousFrame();
            
            return GetNumberOfPinsInThisFrame();
        }

        public int GetNumberOfPinsInThisFrame()
        {
            return Rolls.Sum(roll => roll.Pins);
        }

        private int GetSpareBonusForPreviousFrame()
        {
            return GetNumberOfPinsOfFirstRoll();
        }

        protected virtual int GetStrikeBonusForPreviousFrame()
        {
            if (IsStrike())
            {
                return GetNumberOfPinsInThisFrame() + _nextFrame.GetNumberOfPinsOfFirstRoll();
            }
            return GetNumberOfPinsInThisFrame();
        }     

        private int GetNumberOfPinsOfFirstRoll()
        {
            return Rolls.ElementAt(0)?.Pins ?? 0;
        }


    }
}
