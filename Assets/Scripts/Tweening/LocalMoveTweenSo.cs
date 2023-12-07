using System.Threading.Tasks;
using DG.Tweening;
using TweenStructures;
using UnityEngine;

namespace Tweening
{
	[CreateAssetMenu(fileName = "LocalMoveTween", menuName = "ScriptableObjects/Tweening/LocalMoveTween")]
	public class LocalMoveTweenSo : ScriptableObject, ITweenAnimation, IAwaitableTweenAnimation
	{
		[SerializeField] private Vector3TweenData _move;

		void ITweenAnimation.ApplyTo(Transform transform) => 
			ApplyToInternal(transform);

		async Task IAwaitableTweenAnimation.ApplyTo(Transform transform) =>
			await ApplyToInternal(transform).AsyncWaitForCompletion();

		private Tween ApplyToInternal(Transform transform)
		{
			return transform
				.DOLocalMove(_move.To, _move.Duration)
				.SetEase(_move.Ease);
		}
	}
}