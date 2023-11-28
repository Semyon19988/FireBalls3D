using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Paths
{
	public class PathDrawer : MonoBehaviour
	{
		[SerializeField] private Path _path;

		[Header("Settings")] 
		[SerializeField] private float _waypointRadius = 0.25f;
		[SerializeField] private  Color _waypointColor = Color.red;
		[SerializeField] private  Color _lineColor = Color.red;

		private void OnDrawGizmos()
		{
			if (_path is null)
				return;
			
			IReadOnlyList<Transform> waypoints = GetAllWaypoints(_path.Segments);
			
			DrawWaypoints(waypoints);
			DrawSegmentLines(waypoints);
		}

		private void DrawWaypoints(IEnumerable<Transform> waypoints)
		{
			Gizmos.color = _waypointColor;
			
			foreach (Transform waypoint in waypoints)
				Gizmos.DrawSphere(waypoint.position, _waypointRadius);
		}

		private void DrawSegmentLines(IReadOnlyList<Transform> waypoints)
		{
			if (waypoints.Count < 2)
				return;
			
			Gizmos.color = _lineColor;
			
			for (int i = 1; i < waypoints.Count; i++)
				Gizmos.DrawLine(waypoints[i - 1].position,
					waypoints[i].position);
		}

		private IReadOnlyList<Transform> GetAllWaypoints(IEnumerable<PathSegment> segments)
		{
			Transform[] waypoints = Array.Empty<Transform>();

			foreach (PathSegment segment in segments)
				waypoints = waypoints
					.Union(segment.Waypoints)
					.ToArray();

			return waypoints;
		}
	}
}