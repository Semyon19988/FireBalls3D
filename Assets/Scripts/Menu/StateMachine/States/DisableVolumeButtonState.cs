namespace StateMachine.States
{
	public class DisableVolumeButtonState : ConfigureVolumeButtonState
	{
		protected override float VolumeLevel => - 80.0f;
	}
}