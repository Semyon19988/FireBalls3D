using System.Collections.Generic;

namespace TowerGeneration
{
	public class Tower
	{
		private readonly Queue<TowerSegment> _segments;
		
		public Tower(IEnumerable<TowerSegment> segments) : this(new Queue<TowerSegment>(segments)){ }
		private Tower(Queue<TowerSegment> segments) =>
			_segments = segments;
	}
}