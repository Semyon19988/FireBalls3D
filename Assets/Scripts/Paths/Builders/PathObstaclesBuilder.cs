using System.Collections.Generic;
using Obstacles;
using Obstacles.Disappearing;
using Obstacles.Generation;
using Tweening;
using UnityEngine;

namespace Paths.Builders
{
	public class PathObstaclesBuilder : MonoBehaviour
	{
		[SerializeField] private Transform _root;
		[SerializeField] private LocalMoveTweenSo _disappearAnimation;

		private IReadOnlyList<Obstacle> _obstaclePrefabs;

		public void Initialize(IReadOnlyList<Obstacle> obstaclePrefabs) =>
			_obstaclePrefabs = obstaclePrefabs;

		public ObstaclesDisappearing Build(ObstacleCollisionFeedback feedback)
		{
			ObstaclesGeneration generation = new ObstaclesGeneration(_obstaclePrefabs);
			IEnumerable<Obstacle> obstacles = generation.Create(_root, feedback);
			
			return new ObstaclesDisappearing(_root, obstacles, _disappearAnimation);
		}
	}
}