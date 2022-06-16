namespace Bowling
{
    public class Game
    {
        TurnBuilder turnBuilder;

        List<Turn> turns;

        public Game()
        {
            turns = new List<Turn>();
            turnBuilder = new TurnBuilder();
        }

        public void Roll(int pinsDown)
        {
            turnBuilder.AddRoll(pinsDown);

            if (turnBuilder.IsTurnComplete)
            {
                var newTurn = turnBuilder.GetCompletedTurn();
                turns.Add(newTurn);

                turnBuilder.IsPreviousTurnSpare = newTurn.IsSpare;

                turnBuilder.ResetRoll();
            }
        }

        public int Score()
        {
            return turns.Sum(turn => turn.Score());
        }

        public int PartialScore()
        {
            if (!turnBuilder.IsTurnComplete)
            {
                return turns.Sum(turn => turn.Score()) + turnBuilder.GetPartialTurn().Score();
            }
            else
            {
                return Score();
            }
        }
    }
}