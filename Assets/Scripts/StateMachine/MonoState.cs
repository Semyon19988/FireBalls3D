using UnityEngine;

namespace StateMachine
{
	public abstract class MonoState : MonoBehaviour, IState
	{
		public abstract void Enter();
	}
}
