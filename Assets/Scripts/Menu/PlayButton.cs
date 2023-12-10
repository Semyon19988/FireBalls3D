using GameStates.Base;
using GameStates.States;
using UnityEngine;
using UnityEngine.UI;

namespace Menu
{
	[RequireComponent(typeof(Button))]
	public class PlayButton : MonoBehaviour
	{
		[SerializeField] private GameStateMachineSo _stateMachine;

		private void Start()
		{
			Button button = GetComponent<Button>();
			button.onClick.AddListener(_stateMachine.Enter<LevelEntryStateSo>);
		}
	}
}