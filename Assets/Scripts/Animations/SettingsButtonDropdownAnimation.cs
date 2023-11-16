using DG.Tweening;
using TweenStructures;
using UnityEngine;

namespace Animations
{
	public class SettingsButtonDropdownAnimation : MonoBehaviour
	{
		[SerializeField] private Vector2RangedTweenData _buttonsTweenData;
		[SerializeField] private GameObject _actionRoot;
		[SerializeField] private float _delayBetweenButtons;

		private RectTransform[] _buttonTransforms;
		private bool _active;

		private void Start()
		{
			_buttonTransforms = _actionRoot.GetComponentsInChildren<RectTransform>();
			TweenButtonSizes(_active, _buttonsTweenData);
		}

		public void OnButtonClicked()
		{
			_active = !_active;
			TweenButtonSizes(_active, _buttonsTweenData);
		}

		private void TweenButtonSizes(bool active, Vector2RangedTweenData tweenData)
		{
			float delay = 0.0f;
			foreach (RectTransform buttonTransform in _buttonTransforms)
			{
				Vector2 sizeDelta = active ? tweenData.To : tweenData.From;

				buttonTransform
					.DOSizeDelta(sizeDelta, tweenData.Duration)
					.SetDelay(delay)
					.SetEase(tweenData.Ease);

				delay += _delayBetweenButtons;
			}
		}
	}
}