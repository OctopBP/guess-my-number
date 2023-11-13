namespace Game
{
    class ShowGuessResultState : IGameState
    {
        readonly GameStateMachine stateMachine;
        
        public ShowGuessResultState(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        
        public void OnEnter()
        {
            var lastGuess = stateMachine.roundData.guesses.Peek();
            
            var diff = stateMachine.roundData.targetNumber - lastGuess.guessNumber;
            var resultType = diff switch
            {
                < 0 => GuessResultType.Lower,
                > 0 => GuessResultType.Higher,
                _ => GuessResultType.Correct
            };
            
            var guessResult = new GuessResult(lastGuess, resultType);
            stateMachine.guesses.Add(guessResult);
            
            stateMachine.EnterState(resultType == GuessResultType.Correct
                ? stateMachine.winState
                : stateMachine.playerGuessState
            );
        }

        public void OnExit() {}
    }
}