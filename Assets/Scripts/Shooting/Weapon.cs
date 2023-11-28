using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace Shooting
{
	public class Weapon
	{
		private readonly Transform _shootPoint;
		private readonly Projectile _projectilePrefab;
		private readonly float _projectileSpeed;
		
		public Weapon(Transform shootPoint, Projectile projectilePrefab, float projectileSpeed)
		{
			_shootPoint = shootPoint;
			_projectilePrefab = projectilePrefab;
			_projectileSpeed = projectileSpeed;
		}

		public void Shoot()
		{
			UnityObject
				.Instantiate(_projectilePrefab)
				.Shoot(_shootPoint.position, 
					_shootPoint.forward,
					_projectileSpeed);
		}
	}
}