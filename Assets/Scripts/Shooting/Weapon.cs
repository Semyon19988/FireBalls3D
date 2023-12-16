using Pool;
using UnityEngine;

namespace Shooting
{
	public class Weapon
	{
		private readonly Transform _shootPoint;
		private readonly IPool<Projectile> _pool;
		private readonly float _projectileSpeed;

		public Weapon(Transform shootPoint, IPool<Projectile> pool, float projectileSpeed)
		{
			_shootPoint = shootPoint;
			_pool = pool;
			_projectileSpeed = projectileSpeed;
		}

		public void Shoot() =>
			_pool.Request()
				.Shoot(_shootPoint.position,
					_shootPoint.forward,
					_projectileSpeed);
	}
}