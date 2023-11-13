using System;
using UniRx;
using UnityEngine;

namespace Game
{
    class PlayerGuessState : IGameState
    {
        readonly GameStateMachine stateMachine;
        IDisposable keyboardSubscription;
        
        public PlayerGuessState(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        
        public void OnEnter()
        {
            // Enable keypads and subscribe to input
            stateMachine.keypads.Show();
            keyboardSubscription = stateMachine.keypads.onNumberEnter.Subscribe(NewGuess);
        }

        public void OnExit()
        {
            stateMachine.keypads.Hide();
            keyboardSubscription.Dispose();
        }
        
        void NewGuess(int number)
        {
            var newGuess = new Guess(number);
            stateMachine.roundData.guesses.Push(newGuess);
            stateMachine.EnterState(stateMachine.showGuessResultState);
        }
    }
}