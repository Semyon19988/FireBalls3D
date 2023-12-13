using GameStates.Base;
using Levels;
using Levels.Generation;
using Levels.Interfaces;
using SceneLoading;
using Tools;
using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace GameStates.States
{
	[CreateAssetMenu(fileName = "LevelEntryStateSo", menuName = "ScriptableObjects/Game/States/LevelEntryState")]
	public class LevelEntryStateSo : GameStateSo
	{
		[SerializeField] private Scene _playerGeneratedPathScene;
		[SerializeField] private UnityObject _levelProvider;
		[SerializeField] private PathStructureContainerSo _pathStructureContainer;

		private readonly IAsyncSceneLoading _sceneLoading = new AddressablesSceneLoading();

		private ILevelProvider LevelProvider => (ILevelProvider) _levelProvider;

		private Level Level => LevelProvider.Current;

		private void OnValidate()
		{
			Inspector.ValidateOn<ILevelProvider>(ref _levelProvider);
		}

		public override async void Enter()
		{
			_pathStructureContainer.PathStructure = Level.PathStructure;
			
			await _sceneLoading.LoadAsync(Level.LocationScene);
			await _sceneLoading.LoadAsync(_playerGeneratedPathScene);
		}

		public override void Exit() { }
	}
}