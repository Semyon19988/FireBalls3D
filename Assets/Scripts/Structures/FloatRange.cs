using UnityRandom = UnityEngine.Random;

namespace Structures
{
	[System.Serializable]
	public class FloatRange : Range<float>
	{
		public float Random => UnityRandom.Range(Min, Max);
	}
}