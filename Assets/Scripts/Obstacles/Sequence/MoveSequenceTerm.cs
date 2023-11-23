using System.Collections;
using Structures;
using UnityEngine;

namespace Obstacles.Sequence
{
	public class MoveSequenceTerm : IMovementSequenceTerm
	{
		private readonly IMovement _movement;
		private readonly FloatRange _duration;

		public MoveSequenceTerm(IMovement movement, FloatRange duration)
		{
			_movement = movement;
			_duration = duration;
		}

		public IEnumerator GetSequenceTermCoroutine()
		{
			float enteredTime = Time.time;
			float duration = _duration.Random;
			float speed = _movement.Speed;

			while (Time.time < enteredTime + duration)
			{
				_movement.Move(speed);

				yield return null;
			}
		}
	}
}