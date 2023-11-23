using UnityEngine;

namespace Obstacles
{
	public class RotationMovement : IMovement
	{
		private readonly Transform _transform;
		private readonly Vector3 _axis;

		public RotationMovement(Transform transform, Vector3 axis)
		{
			_transform = transform;
			_axis = axis;
		}
		public float Speed { get; private set; }

		public void Move(float speed)
		{
			Speed = speed;
			_transform.Rotate(_axis, speed * Time.deltaTime);
		}
	}
}