using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    internal class Turn
    {
        private int firstRoll;
        private int secondRoll;
        private readonly bool previousWasSpare;

        public Turn(int firstRoll, int secondRoll, bool previousWasSpare)
        {
            this.firstRoll = firstRoll;
            this.secondRoll = secondRoll;
            this.previousWasSpare = previousWasSpare;
        }

        public int Score()
        {
            if (previousWasSpare)
            {
                return firstRoll * 2 + secondRoll;
            }
            return firstRoll + secondRoll;
        }

        public bool IsSpare => firstRoll + secondRoll == 10;
    }
}
