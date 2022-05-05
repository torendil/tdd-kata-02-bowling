namespace Bowling
{
    public class Game
    {
        int totalScore;

        public void Roll(int pinsDown)
        {
            totalScore += pinsDown;
        }

        public int Score()
        {
            return totalScore;
        }
    }
}