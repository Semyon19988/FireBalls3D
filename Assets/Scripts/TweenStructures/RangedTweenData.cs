using UnityEngine;

namespace TweenStructures
{
	[System.Serializable]
	public class Vector3RangedTweenData : RangedTweenData<Vector3> { }
	[System.Serializable]
	public class Vector2RangedTweenData : RangedTweenData<Vector2> { }
	public class RangedTweenData<T> : TweenData<T>
	{
		public T From;
	}
}