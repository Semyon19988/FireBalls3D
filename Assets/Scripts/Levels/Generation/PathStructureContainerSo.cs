using UnityEngine;

namespace Levels.Generation
{
	[CreateAssetMenu(fileName = "PathStructureContainer", menuName = "ScriptableObjects/Levels/PathStructureContainer")]
	public class PathStructureContainerSo : ScriptableObject
	{
		public PathStructureSo PathStructure { get; set; }
	}
}