using JetBrains.Annotations;

namespace Game
{
    class GameStateMachine
    {
        public readonly GameConfig gameConfig;
        public readonly Keypads keypads;
        public readonly Guesses guesses;
        
        public readonly IGameState chooseRandomNumberState, playerGuessState, showGuessResultState;

        [CanBeNull] IGameState currentState;
        [CanBeNull] public RoundData roundData;
    
        public GameStateMachine(GameConfig gameConfig, Keypads keypads, Guesses guesses)
        {
            this.gameConfig = gameConfig;
            this.keypads = keypads;
            this.guesses = guesses;

            // Init states
            chooseRandomNumberState = new ChooseRandomNumberState(this);
            playerGuessState = new PlayerGuessState(this);
            showGuessResultState = new ShowGuessResultState(this);
        
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