namespace BowlingGame.NET.src
{
    internal class Roll
    {
        public int pins { get; }

        public Roll(int pins)
        {
            this.pins = pins;
        }      

        public bool IsGutterBall()
        {
            return pins == 0;
        }

        public bool IsStrike()
        {
            return 10 == pins;
        }

    }
}
