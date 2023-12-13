using System.Threading;
using GameStates.Base;
using Paths;
using Paths.Completion;
using UnityEngine;

namespace Players
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private MovePreferencesSo _movePreferences;
		[SerializeField] private GameStateMachineSo _stateMachine;

		[Header("Player")] 
		[SerializeField] private PlayerInputHandler _inputHandler;
		[SerializeField] private Transform _player;

		public void StartMovingOn(Path path, Vector3 initialPosition, CancellationTokenSource cancellationTokenSource)
		{
			_player.position = initialPosition;

			new PlayerPathFollowing(
					new PathFollowing(path, _player, _movePreferences),
					path, _inputHandler, new LevelPathCompletion(_stateMachine))
					.StartMovingAsync(cancellationTokenSource.Token);
		}
	}
}