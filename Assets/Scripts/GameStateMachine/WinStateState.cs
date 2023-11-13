using System;
using UniRx;

namespace Game
{
    class WinState : IGameState
    {
        readonly GameStateMachine stateMachine;
    
        public WinState(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    
        public void OnEnter()
        {
            // Set result
            stateMachine.resultView.SetResult(stateMachine.roundData);
            
            Observable
                .Timer(TimeSpan.FromSeconds(3))
                .Subscribe(_ => stateMachine.EnterState(stateMachine.chooseRandomNumberState));
        }

        public void OnExit() { }
    }
}