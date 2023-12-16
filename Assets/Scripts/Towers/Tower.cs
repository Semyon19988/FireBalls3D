using System.Collections.Generic;
using Structures.ReactiveProperties;

namespace Towers
{
	public class Tower
	{
		private readonly Queue<TowerSegment> _segments;
		private readonly ReactiveProperty<int> _segmentCount;

		public Tower(IEnumerable<TowerSegment> segments) : this(new Queue<TowerSegment>(segments)) { }
		
		public Tower(Queue<TowerSegment> segments)
		{
			_segments = segments;
			_segmentCount = new ReactiveProperty<int>(segments.Count);
		}

		public IReadOnlyReactiveProperty<int> SegmentCount => _segmentCount;

		public TowerSegment RemoveBottom()
		{
			TowerSegment segment = _segments.Dequeue();
			_segmentCount.Change(_segments.Count);
			return segment;
		}
	}
}