namespace BowlingGame.NET
{
    public class Roll
    {
        public int Pins { get; }

        public Roll(int Pins)
        {
            this.Pins = Pins;
        }      

        public bool IsGutterBall()
        {
            return Pins == 0;
        }

        public bool IsStrike()
        {
            return 10 == Pins;
        }

    }
}
