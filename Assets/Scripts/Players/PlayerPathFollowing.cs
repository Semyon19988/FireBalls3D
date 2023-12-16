using System.Collections.Generic;
using System.Threading;
using Obstacles.Disappearing;
using Paths;
using Paths.Completion;
using Towers.Disassembling;

namespace Players
{
	public class PlayerPathFollowing
	{
		private readonly PathFollowing _pathFollowing;
		private readonly Path _path;
		private readonly PlayerInputHandler _inputHandler;
		private readonly IPathCompletion _pathCompletion;
		
		public PlayerPathFollowing(PathFollowing pathFollowing, Path path, PlayerInputHandler inputHandler, IPathCompletion pathCompletion)
		{
			_pathFollowing = pathFollowing;
			_path = path;
			_inputHandler = inputHandler;
			_pathCompletion = pathCompletion;
		}

		public async void StartMovingAsync(CancellationToken cancellationToken)
		{
			IReadOnlyList<PathSegment> segments = _path.Segments;
			
			foreach (PathSegment pathSegment in segments)
			{
				_inputHandler.Disable();
				await _pathFollowing.MoveToNextAsync();

				(TowerDisassembling towerDisassembling, ObstaclesDisappearing obstaclesDisappearing) 
					= await pathSegment.PlatformBuilder.BuildAsync();

				if (cancellationToken.IsCancellationRequested)
					return;
				
				_inputHandler.Enable();
				
				await towerDisassembling;
				await obstaclesDisappearing.ApplyAsync();
			}
			_inputHandler.Disable();
			_pathCompletion.Complete();
		}
	}
}