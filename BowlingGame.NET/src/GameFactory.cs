namespace BowlingGame.NET
{
    public class GameFactory
    {
        public virtual Game Create()
        {
            var frames = new Frame[10];

            frames[9] = new TripleFrame();
            for (var count = 8; count >= 0; count--)
            {
                frames[count] = new Frame(frames[count + 1]);
            }

            return new Game(frames);
        }
    }
}

