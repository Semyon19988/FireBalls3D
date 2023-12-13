using System;
using Levels.Interfaces;
using Tools;
using UnityEngine;
using UnityEngine.AddressableAssets;
using  UnityObject = UnityEngine.Object;

namespace Menu.Levels
{
	public class MenuPlatformSequence : MonoBehaviour
	{
		[SerializeField] private MenuLevel[] _levels = Array.Empty<MenuLevel>();
		[SerializeField] private AssetReferenceGameObject _levelMarker;

		[SerializeField] private UnityObject _levelNumberProvider;
		[SerializeField] private LevelColorsSo _colors;

		private ILevelNumberProvider LevelNumberProvider => (ILevelNumberProvider) _levelNumberProvider;

		private int NextLevelNumber => LevelNumberProvider.Value;

		private void OnValidate()
		{
			Inspector.ValidateOn<ILevelNumberProvider>(ref _levelNumberProvider);
		}

		private void Start()
		{
			Transform markerHolder = _levels[NextLevelNumber - 1].MarkerHolder;
			_levelMarker.InstantiateAsync(markerHolder);
			
			for (int i = 0; i < NextLevelNumber - 1; i++)
				_levels[i].PaintNumber(_colors.PassedLevels);
			for (int i = NextLevelNumber; i < _levels.Length; i++)
				_levels[i].PaintNumber(_colors.NextLevels);
		}
	}
}