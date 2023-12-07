using DG.Tweening;
using TweenStructures;
using UnityEngine;

namespace Tweening
{
	[CreateAssetMenu(fileName = "FastRotationTween", menuName = "ScriptableObjects/Tweening/FastRotationTween")]
	public class FastRotationTweenSo : ScriptableObject
	{
		[SerializeField] private Vector3TweenData _rotation;

		public void ApplyTo(Transform transform) =>
			ApplyTo(transform, _rotation);

		public void ApplyTo(Transform transform, Vector3TweenData rotation) =>
			transform
				.DORotate(rotation.To, rotation.Duration, RotateMode.FastBeyond360)
				.SetEase(rotation.Ease);
	}
}