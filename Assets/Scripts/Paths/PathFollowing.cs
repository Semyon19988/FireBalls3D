using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Paths
{
	public class PathFollowing
	{
		private readonly Path _path;
		private readonly Transform _follower;
		private readonly MovePreferencesSo _preferences;

		private int _pathSegmentIndex;

		public PathFollowing(Path path, Transform follower, MovePreferencesSo preferences)
		{
			_path = path;
			_follower = follower;
			_preferences = preferences;
		}

		public async Task MoveToNextAsync()
		{
			if (_pathSegmentIndex >= _path.Segments.Count)
				return;

			PathSegment segment = _path.Segments[_pathSegmentIndex];
			Transform[] waypoints = segment.Waypoints;

			await MoveBetweenAsync(_follower, waypoints);
		}

		private async Task MoveBetweenAsync(Transform follower, IReadOnlyList<Transform> waypoints)
		{
			int index = 1;

			while (index < waypoints.Count)
			{
				Vector3 position = waypoints[index].position;

				Task lookAt = follower
					.DOLookAt(position, _preferences.RotationDuration)
					.AsyncWaitForCompletion();


				Task move = follower
					.DOMove(position, _preferences.DurationPerWaypoint)
					.AsyncWaitForCompletion();

				await Task.WhenAll(lookAt, move);

				index++;
			}

			_pathSegmentIndex++;
		}
	}
}