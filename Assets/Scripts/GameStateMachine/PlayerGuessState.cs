using UnityEngine;

namespace Game
{
    class PlayerGuessState : IGameState
    {
        readonly GameStateMachine stateMachine;
        
        public PlayerGuessState(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        
        public void OnEnter()
        {
            // Enable keypads and subscribe to input
            stateMachine.keypads.Show();
            stateMachine.keypads.OnNumberEnter += NewGuess;
        }

        public void OnExit()
        {
            stateMachine.keypads.Hide();
            stateMachine.keypads.OnNumberEnter -= NewGuess;
        }
        
        void NewGuess(int number)
        {
            var newGuess = new Guess(number);
            stateMachine.roundData.guesses.Push(newGuess);
            stateMachine.EnterState(stateMachine.showGuessResultState);
        }
    }
}