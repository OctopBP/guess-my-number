using System;

namespace Game
{
    class ChooseRandomNumberState : IGameState
    {
        readonly GameStateMachine stateMachine;
        readonly Random rnd = new();
    
        public ChooseRandomNumberState(GameStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    
        public void OnEnter()
        {
            var range = stateMachine.gameConfig.numberRange;
            var targetNumber = rnd.Next(range.start, range.end);
            
            stateMachine.roundData = new(targetNumber);
            stateMachine.EnterState(stateMachine.playerGuessState);
        }

        public void OnExit() { }
    }
}