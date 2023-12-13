using TMPro;
using UnityEngine;

namespace Menu.Levels
{
	public class MenuLevel : MonoBehaviour
	{
		[SerializeField] private Transform _markerHolder;
		[SerializeField] private TextMeshPro _number;

		public Transform MarkerHolder => _markerHolder;

		public void PaintNumber(Color color) =>
			_number.color = color;
	}
}