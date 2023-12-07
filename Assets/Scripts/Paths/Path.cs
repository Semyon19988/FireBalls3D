using System;
using System.Collections.Generic;
using Obstacles;
using Paths.Builders;
using UnityEngine;

namespace Paths
{
	public class Path : MonoBehaviour
	{
		[SerializeField] private PathSegment[] _segments = Array.Empty<PathSegment>();
		
		public IReadOnlyList<PathSegment> Segments => _segments;

		public void Initialize(IReadOnlyList<PathPlatformStructure> platformStructures,
			ObstacleCollisionFeedback feedback)
		{
			for (int i = 0; i < platformStructures.Count; i++)
			{
				PathPlatformBuilder builder = _segments[i].PlatformBuilder;
				builder.Initialize(platformStructures[i], feedback);
			}
		}
	}
}