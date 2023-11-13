using System.Collections.Generic;

namespace Game
{
    class RoundData
    {
        public readonly int targetNumber;
        public readonly Stack<Guess> guesses = new();
        
        public RoundData(int targetNumber)
        {
            this.targetNumber = targetNumber;
        }
    }
}