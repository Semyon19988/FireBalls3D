using DG.Tweening;
using TweenStructures;
using UnityEngine;

namespace Animations
{
	public class ScaleAnimation : MonoBehaviour
	{
		[SerializeField] private Vector3RangedTweenData _tweenData;

		private void Start() =>
			ApplyAnimation(_tweenData);

		private void ApplyAnimation(Vector3RangedTweenData tweenData) =>
			transform
				.DOScale(tweenData.To, tweenData.Duration)
				.SetEase(tweenData.Ease)
				.SetLoops(-1, LoopType.Yoyo);
	}
}