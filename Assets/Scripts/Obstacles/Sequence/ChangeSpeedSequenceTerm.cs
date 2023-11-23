using System.Collections;
using Structures;
using UnityEngine;

namespace Obstacles.Sequence
{
	public class ChangeSpeedSequenceTerm : IMovementSequenceTerm
	{
		private const float PositiveSpeedChangePercent = 0.5f;

		private readonly IMovement _movement;
		private readonly FloatRange _speed;
		private readonly FloatRange _duration;
		private readonly AnimationCurve _curve;

		public ChangeSpeedSequenceTerm(IMovement movement, FloatRange speed, FloatRange duration, AnimationCurve curve)
		{
			_movement = movement;
			_speed = speed;
			_duration = duration;
			_curve = curve;
		}

		public IEnumerator GetSequenceTermCoroutine()
		{
			float enteredTime = Time.time;
			float duration = _duration.Random;

			float enteredSpeed = _movement.Speed;
			float newSpeed = ChooseSpeed(_speed);
			
			while (Time.time < enteredSpeed + duration)
			{
				float elapsedTimePercent = (Time.time - enteredSpeed) / duration;

				float difference = newSpeed - enteredSpeed;
				float scaledDifference = difference * _curve.Evaluate(elapsedTimePercent);

				float speed = enteredSpeed + scaledDifference;
				
				_movement.Move(speed);

				yield return null;
			}
		}

		private float ChooseSpeed(FloatRange speed)
		{
			return Random.value > PositiveSpeedChangePercent
				? speed.Random
				: -speed.Random;
		}
	}
}