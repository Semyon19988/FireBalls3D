using System;
using UnityEngine;

namespace Triggers
{
	public class DestroyTrigger : MonoBehaviour
	{
		private void OnTriggerEnter(Collider other) => 
			Destroy(other.gameObject);
	}
}