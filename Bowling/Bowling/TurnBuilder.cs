
namespace Bowling
{
    internal class TurnBuilder
    {
        int? firstRoll;
        int? secondRoll;

        internal bool IsPreviousTurnSpare { get; set; }

        /// <summary>
        /// <para>Adds a new roll to an existing or new turn.</para>
        /// If you want to add rolls to a new turn after a completed one, you have to reset the builder by calling <see cref="ResetRoll"/>
        /// </summary>
        /// <param name="pinsDown"></param>
        internal void AddRoll(int pinsDown)
        {
            if (firstRoll == null)
            {
                firstRoll = pinsDown;
            }
            else
            {
                secondRoll = pinsDown;
            }
        }

        internal bool IsTurnComplete => firstRoll != null && secondRoll != null;

        internal Turn GetCompletedTurn()
        {
            if (firstRoll == null || secondRoll == null)
            {
                throw new InvalidOperationException("Turn is not complete");
            }
            return new Turn(firstRoll.Value, secondRoll.Value, IsPreviousTurnSpare);
        }

        internal Turn GetPartialTurn()
        {
            if (firstRoll == null)
            {
                throw new InvalidOperationException("Turn is not complete");
            }
            return new Turn(firstRoll.Value, 0, IsPreviousTurnSpare);
        }

        internal void ResetRoll()
        {
            firstRoll = null;
            secondRoll = null;
        }
    }
}
