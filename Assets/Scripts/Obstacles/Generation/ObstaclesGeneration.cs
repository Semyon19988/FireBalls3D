using System.Collections.Generic;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Obstacles.Generation
{
	public class ObstaclesGeneration
	{
		private readonly IReadOnlyList<Obstacle> _obstaclePrefabs;

		public ObstaclesGeneration(IReadOnlyList<Obstacle> obstaclePrefabs)
		{
			_obstaclePrefabs = obstaclePrefabs;
		}

		public IEnumerable<Obstacle> Create(Transform root, ObstacleCollisionFeedback feedback)
		{
			var createdObstacles = new Obstacle[_obstaclePrefabs.Count];

			for (var i = 0; i < _obstaclePrefabs.Count; i++)
			{
				Obstacle createdObstacle = UnityObject.Instantiate(_obstaclePrefabs[i], root);
				createdObstacle.Initialize(feedback);
				createdObstacle.transform.eulerAngles = GetRandomYRotation();
				createdObstacles[i] = createdObstacle;
			}

			return createdObstacles;
		}

		private Vector3 GetRandomYRotation() => 
			Vector3.up * Random.Range(0.0f, 360.0f);
	}
}