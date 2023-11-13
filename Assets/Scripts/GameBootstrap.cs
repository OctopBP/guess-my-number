using UnityEngine;

namespace Game
{
    public class GameBootstrap : MonoBehaviour
    {
        [SerializeField] Transform keypadsParent;
        [SerializeField] Keypad keypadButtonPrefab;
        
        [SerializeField] Transform guessResultsParent;
        [SerializeField] GuessResultView guessResultViewPrefab;

        void Start()
        {
            var keypads = new Keypads(keypadButtonPrefab, keypadsParent);
            var guesses = new Guesses(guessResultViewPrefab, guessResultsParent);
            var gameConfig = new GameConfig(numberRange: new(1, 9));
            
            _ = new GameStateMachine(gameConfig, keypads, guesses);
        }
    }
}