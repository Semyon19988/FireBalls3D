using System;
using System.Collections;
using UnityEngine;

namespace Shooting
{
	[RequireComponent(typeof(Rigidbody))]
	public class Projectile : MonoBehaviour
	{
		private Rigidbody _rigidbody;

		private void Awake() => 
			_rigidbody = GetComponent<Rigidbody>();

		public void Shoot(Vector3 position, Vector3 direction, float speed)
		{
			transform.position = position;
			StartCoroutine(MoveAlong(direction, speed));
		}

		private IEnumerator MoveAlong(Vector3 direction, float speed)
		{
			while (true)
			{
				Vector3 newPosition = _rigidbody.position + direction * (speed * Time.deltaTime);
				_rigidbody.MovePosition(newPosition);
				yield return null;
			}
		}
	}
}