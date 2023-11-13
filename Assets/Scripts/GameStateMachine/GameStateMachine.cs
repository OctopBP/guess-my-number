using JetBrains.Annotations;
using TMPro;

namespace Game
{
    class GameStateMachine
    {
        public readonly GameConfig gameConfig;
        public readonly Keypads keypads;
        public readonly Guesses guesses;
        public readonly ResultView resultView;
        
        public readonly IGameState chooseRandomNumberState, playerGuessState, showGuessResultState, winState;

        [CanBeNull] IGameState currentState;
        [CanBeNull] public RoundData roundData;
    
        public GameStateMachine(GameConfig gameConfig, Keypads keypads, Guesses guesses, ResultView resultView)
        {
            this.gameConfig = gameConfig;
            this.keypads = keypads;
            this.guesses = guesses;
            this.resultView = resultView;

            // Init states
            chooseRandomNumberState = new ChooseRandomNumberState(this);
            playerGuessState = new PlayerGuessState(this);
            showGuessResultState = new ShowGuessResultState(this);
            winState = new WinState(this);
        
            // Enter first state
            EnterState(chooseRandomNumberState);
        }

        public void EnterState(IGameState newState)
        {
            currentState?.OnExit();
            currentState = newState;
            currentState.OnEnter();
        }
    }
}