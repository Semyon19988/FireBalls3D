using Input.Touches;
using UnityEngine;
using Touch = Input.Touches.Touch;

namespace Players
{
	public class PlayerInputHandler : MonoBehaviour
	{
		[Header("Input")]
		[SerializeField] private InputTouchPanel _touchPanel;

		[Header("Player Components")] 
		[SerializeField] private Player _player;

		private void OnEnable() =>
			_touchPanel.Holding += Shoot;
		private void OnDisable() => 
			_touchPanel.Holding -= Shoot;

		public void Enable() =>
			enabled = true;
		
		public void Disable() =>
			enabled = false;
		
		private void Shoot(Touch touch) =>
			_player.Shoot();
	}
}