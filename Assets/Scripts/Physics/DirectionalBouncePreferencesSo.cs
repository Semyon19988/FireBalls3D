using UnityEngine;

namespace Physics
{
	[CreateAssetMenu(fileName = "DirectionalBouncePreferences", menuName = "ScriptableObjects/Physics/DirectionalBouncePreferences")]
	public class DirectionalBouncePreferencesSo : ScriptableObject
	{
		[SerializeField] private DirectionalBouncePreferences _value;

		public DirectionalBouncePreferences Value => _value;
	}
}