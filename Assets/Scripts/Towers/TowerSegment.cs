using UnityEngine;

namespace Towers
{
	public class TowerSegment : MonoBehaviour
	{
		public void SetMaterial(Material material) =>
			GetComponent<MeshRenderer>().sharedMaterial = material;
	}
}
