namespace BowlingGame.NET
{
    internal class Roll
    {
        internal int Pins { get; }

        internal Roll(int pins)
        {
            this.Pins = pins;
        }

        internal bool IsGutterBall()
        {
            return Pins == 0;
        }

        internal bool IsStrike()
        {
            return 10 == Pins;
        }

    }
}
