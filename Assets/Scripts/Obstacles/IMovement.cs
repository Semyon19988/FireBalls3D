namespace Obstacles
{
	public interface IMovement
	{
		float Speed { get; }
		void Move(float speed);
	}
}