using UnityEngine;

namespace Structures
{
	public class UnityTimer
	{
		private float _enteredTime;
		private float _duration;
		
		public bool IsTimeUp => Time.time >= _enteredTime + _duration;

		public float ElapsedTimePercent => (Time.time - _enteredTime) / _duration;

		public void Start(float duration)
		{
			_enteredTime = Time.time;
			_duration = duration;
		}
	}
}