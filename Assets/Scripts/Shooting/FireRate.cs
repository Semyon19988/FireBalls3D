using UnityEngine;

namespace Shooting
{
	public class FireRate
	{
		private readonly float _value;

		private float _lastShootTime;

		public FireRate(float value) => _value = value;

		private bool CanShoot => 
			Time.time >= _lastShootTime + 1.0f / _value;

		public void Shoot(Weapon weapon)
		{
			if (CanShoot == false)
				return;
			
			weapon.Shoot();
			_lastShootTime = Time.time;
		}
	}
}