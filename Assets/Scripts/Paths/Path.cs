using System;
using System.Collections.Generic;
using UnityEngine;

namespace Paths
{
	public class Path : MonoBehaviour
	{
		[SerializeField] private PathSegment[] _segments = Array.Empty<PathSegment>();
		
		public IReadOnlyList<PathSegment> Segments => _segments;
	}
}