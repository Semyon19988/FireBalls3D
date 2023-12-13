using UnityEngine;

namespace Levels
{
	[CreateAssetMenu(fileName = "LevelNumber", menuName = "ScriptableObjects/Levels/LevelNumber")]
	public class LevelNumberSo : ScriptableObject
	{
		public int Value;
	}
}