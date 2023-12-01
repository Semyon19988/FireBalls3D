using UnityEngine;

namespace Shooting.Pool
{
	public class RestoreProjectilePoolTrigger : MonoBehaviour
	{
		[SerializeField] private ProjectilePool _pool;

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out Projectile projectile) == false)
				return;
			
			_pool.Return(projectile);
		}
	}
}