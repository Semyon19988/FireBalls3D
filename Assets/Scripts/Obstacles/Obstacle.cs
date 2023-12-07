using UnityEngine;

namespace Obstacles
{
	public class Obstacle : MonoBehaviour
	{
		[SerializeField] private ObstacleCollision _collision;

		public void Initialize(ObstacleCollisionFeedback feedback)
		{
			_collision.Initialize(feedback);
		}
	}
}