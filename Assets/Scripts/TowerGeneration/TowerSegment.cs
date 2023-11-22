using UnityEngine;

namespace TowerGeneration
{
	public class TowerSegment : MonoBehaviour
	{
		public void SetMaterial(Material material) =>
			GetComponent<MeshRenderer>().sharedMaterial = material;
	}
}
