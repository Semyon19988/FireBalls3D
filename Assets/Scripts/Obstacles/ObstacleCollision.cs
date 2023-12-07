using Coroutines;
using Physics;
using Players;
using Shooting;
using Shooting.Pool;
using UnityEngine;

namespace Obstacles
{
	[System.Serializable]
	public struct ObstacleCollisionFeedback
	{
		public Transform Player;
		public PlayerInputHandler PlayerInputHandler;
		public ProjectilePool PlayerProjectilePool;
	}
	
	public class ObstacleCollision : MonoBehaviour
	{
		[SerializeField] private ProjectileFactory _projectileFactory;
		[SerializeField] private DirectionalBouncePreferencesSo _bouncePreferences;

		private bool _hasAlreadyCollided;
		private ObstacleCollisionFeedback _obstacleCollisionFeedback;

		public void Initialize(ObstacleCollisionFeedback feedback)
		{
			_obstacleCollisionFeedback = feedback;
		}

		private void OnCollisionEnter(Collision other)
		{
			if (other.gameObject.TryGetComponent(out Projectile projectile) == false)
				return;
			
			if (_hasAlreadyCollided)
				return;
			
			_hasAlreadyCollided = true;
			
			_obstacleCollisionFeedback.PlayerProjectilePool.Return(projectile);
			_obstacleCollisionFeedback.PlayerInputHandler.Disable();
			_obstacleCollisionFeedback.PlayerProjectilePool.Disable();

			Vector3 hitPoint = other.contacts[0].point;

			Projectile playerHitProjectile = _projectileFactory.Create();
			
			new DirectionalBounce(playerHitProjectile.transform,
				new CoroutineExecutor(playerHitProjectile),
				_bouncePreferences.Value)
				.BounceTo(_obstacleCollisionFeedback.Player.position, hitPoint);
		}
	}
}