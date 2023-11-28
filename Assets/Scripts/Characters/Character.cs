using UnityEngine;

namespace Characters
{
	public class Character : MonoBehaviour
	{
		[SerializeField] private Transform _shootPoint;

		public Transform ShootPoint => _shootPoint;
	}
}