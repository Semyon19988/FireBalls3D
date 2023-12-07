using System;
using UnityEngine;

namespace Towers.Generation
{
	[CreateAssetMenu(fileName = "TowerStructure", menuName = "ScriptableObjects/Tower/Structure")]
	public class TowerStructureSo : ScriptableObject
	{
		[SerializeField] private TowerSegment _segmentPrefab;

		[Space] 
		[SerializeField] [Min(0)] private int _segmentCount;
		[SerializeField] [Min(0.0f)] private float _spawnTimePerSegment;

		[Space] 
		[SerializeField] private Material[] _materials = Array.Empty<Material>();
		
		public int SpawnTimePerSegmentMilliseconds => (int) (_spawnTimePerSegment * 1000);

		public TowerSegment SegmentPrefab => _segmentPrefab;

		public int SegmentCount => _segmentCount;

		public TowerSegment CreateSegment(Transform tower, Vector3 position, int numberOfInstance)
		{
			TowerSegment segment = Instantiate(_segmentPrefab, position, tower.rotation, tower);

			Material material = GetSegmentMaterialBy(numberOfInstance);
			segment.SetMaterial(material);

			return segment;
		}
		private Material GetSegmentMaterialBy(int numberOfInstance)
		{
			int index = numberOfInstance % _materials.Length;
			return _materials[index];
		}
		
	}
}