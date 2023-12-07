using System.Threading.Tasks;
using Obstacles;
using Obstacles.Disappearing;
using Towers;
using Towers.Disassembling;
using UnityEngine;

namespace Paths.Builders
{
	public class PathPlatformBuilder : MonoBehaviour
	{
		[SerializeField] private PathTowerBuilder _towerBuilder;
		[SerializeField] private PathObstaclesBuilder _pathObstaclesBuilder;

		private ObstacleCollisionFeedback _obstacleCollisionFeedback;

		public void Initialize(PathPlatformStructure pathPlatformStructure, ObstacleCollisionFeedback collisionFeedback)
		{
			_towerBuilder.Initialize(pathPlatformStructure.TowerStructure);
			_pathObstaclesBuilder.Initialize(pathPlatformStructure.Obstacles);

			_obstacleCollisionFeedback = collisionFeedback;
		}

		public async Task<(TowerDisassembling, ObstaclesDisappearing)> BuildAsync()
		{
			TowerDisassembling disassembling =
				await _towerBuilder.BuildAsync(_obstacleCollisionFeedback.PlayerProjectilePool);
			ObstaclesDisappearing disappearing = _pathObstaclesBuilder.Build(_obstacleCollisionFeedback);

			return (disassembling, disappearing);
		}
	}
}