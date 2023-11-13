using TMPro;
using UnityEngine;

namespace Game
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] GameConfig gameConfig;
        
        [SerializeField] TMP_Text resultText;
        
        [SerializeField] Transform keypadsParent;
        [SerializeField] Keypad keypadButtonPrefab;
        
        [SerializeField] Transform guessResultsParent;
        [SerializeField] GuessResultView guessResultViewPrefab;

        void Start()
        {
            var keypads = new Keypads(keypadButtonPrefab, keypadsParent, gameConfig.numberRange);
            var guesses = new Guesses(guessResultViewPrefab, guessResultsParent);
            var resultView = new ResultView(resultText);
            
            _ = new GameStateMachine(gameConfig, keypads, guesses, resultView);
        }
    }
}