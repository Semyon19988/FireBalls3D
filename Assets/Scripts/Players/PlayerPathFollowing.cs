using System.Collections.Generic;
using Obstacles.Disappearing;
using Paths;
using Towers.Disassembling;

namespace Players
{
	public class PlayerPathFollowing
	{
		private readonly PathFollowing _pathFollowing;
		private readonly Path _path;
		private readonly PlayerInputHandler _inputHandler;

		public PlayerPathFollowing(PathFollowing pathFollowing, Path path, PlayerInputHandler inputHandler)
		{
			_pathFollowing = pathFollowing;
			_path = path;
			_inputHandler = inputHandler;
		}

		public async void StartMovingAsync()
		{
			IReadOnlyList<PathSegment> segments = _path.Segments;

			foreach (PathSegment pathSegment in segments)
			{
				_inputHandler.Disable();
				await _pathFollowing.MoveToNextAsync();

				(TowerDisassembling towerDisassembling, ObstaclesDisappearing obstaclesDisappearing)
					= await pathSegment.PlatformBuilder.BuildAsync();
				
				_inputHandler.Enable();

				await towerDisassembling;
				await obstaclesDisappearing.ApplyAsync();
			}
		}
	}
}