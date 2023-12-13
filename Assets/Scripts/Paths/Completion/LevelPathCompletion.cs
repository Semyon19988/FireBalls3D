using GameStates.Base;
using GameStates.States;

namespace Paths.Completion
{
	public class LevelPathCompletion : IPathCompletion
	{
		private readonly IGameStateMachine _stateMachine;

		public LevelPathCompletion(IGameStateMachine stateMachine)
		{
			_stateMachine = stateMachine;
		}

		public void Complete() =>
			_stateMachine.Enter<LevelCompletedState>();
	}
}