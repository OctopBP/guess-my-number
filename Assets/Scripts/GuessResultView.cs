using TMPro;
using UnityEngine;

namespace Game
{
    public class Guess
    {
        public readonly int guessNumber;

        public Guess(int guessNumber)
        {
            this.guessNumber = guessNumber;
        }
    }

    public class GuessResult
    {
        public readonly Guess guess;
        public readonly GuessResultType result;
        
        public GuessResult(Guess guess, GuessResultType result)
        {
            this.guess = guess;
            this.result = result;
        }
    }
    
    public enum GuessResultType
    {
        /// <summary> You get  the right number. </summary>
        Correct,
        /// <summary> Your number is lower, than target one. </summary>
        Lower,
        /// <summary> Your number is higher, than target one. </summary>
        Higher
    }
    
    public class GuessResultView : MonoBehaviour
    {
        [SerializeField] TMP_Text text;
        [SerializeField] Color correctColor, lowerColor, higherColor;

        public void SetResult(GuessResult guessResult)
        {
            var symbol = guessResult.result switch
            {
                GuessResultType.Correct => "=",
                GuessResultType.Lower => "↓",
                GuessResultType.Higher => "↑"
            };
            text.SetText($"{symbol}{guessResult.guess.guessNumber}");
            
            text.color = guessResult.result switch
            {
                GuessResultType.Correct => correctColor,
                GuessResultType.Lower => lowerColor,
                GuessResultType.Higher => higherColor
            };
        }
    }
}
