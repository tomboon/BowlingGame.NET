namespace BowlingGame.NET.src
{
    public class GameFactory
    {
        public Game create()
        {
            Frame[] frames = new Frame[10];

            frames[9] = new TripleFrame();
            for (int count = 8; count >= 0; count--)
            {
                frames[count] = new Frame(frames[count + 1]);
            }

            return new Game(frames);
        }
    }
}

