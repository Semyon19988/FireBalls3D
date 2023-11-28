using Characters;
using Paths;
using Shooting;
using UnityEngine;

namespace PlayerComponents
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private Character _character;
		[SerializeField] private ShootingPreferencesSo _shootingPreferences;
		
		[SerializeField] private Path _path;
		[SerializeField] private MovePreferencesSo _movePreferences;

		private FireRate _fireRate;
		private Weapon _weapon;
		private PathFollowing _pathFollowing;

		private void Start()
		{
			_weapon = _shootingPreferences.CreateWeapon(_character.ShootPoint);
			_fireRate = _shootingPreferences.CreateFireRate();
			_pathFollowing = new PathFollowing(_path,this, _movePreferences);
		}

		public void Shoot() =>
			_fireRate.Shoot(_weapon);

		[ContextMenu(nameof(Move))]
		public void Move() =>
			_pathFollowing.MoveToNext();



















	}
}