using UnityEngine;

namespace Characters
{
	[CreateAssetMenu(fileName = "CharacterContainer", menuName = "ScriptableObjects/Characters/CharacterContainer")]
	public class CharacterContainerSo : ScriptableObject
	{
		public Character CharacterPrefab;

		public Character Create(Transform parent) =>
			Instantiate(CharacterPrefab, parent);
	}
}