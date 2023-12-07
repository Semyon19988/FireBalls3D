using Obstacles;
using Paths;
using Players;
using UnityEngine;

namespace Levels.Generation
{
	public class LevelBuilder : MonoBehaviour
	{
		[Header("Path")] 
		[SerializeField] private Transform _pathRoot;
		[SerializeField] private LevelStructureSo _structure;

		[Header("Player")] 
		[SerializeField] private ObstacleCollisionFeedback _obstacleCollisionFeedback;
		[SerializeField] private PlayerMovement _playerMovement;

		private void Start() =>
			Build();

		private void Build()
		{
			Path path = _structure.CreatePath(_pathRoot, _obstacleCollisionFeedback);
			Vector3 initialPosition = path.Segments[0].Waypoints[0].position;

			_playerMovement.StartMovingOn(path, initialPosition);
		}
	}
}