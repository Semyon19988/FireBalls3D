using UnityEngine;
using UnityEngine.Audio;

namespace StateMachine.States
{
	public abstract class ConfigureVolumeButtonState : IconChangeButtonState
	{
		[Header("Volume Settings")] 
		[SerializeField] private string _volumeExposedParameter;
		[SerializeField] private AudioMixer _audioMixer;
		protected abstract float VolumeLevel { get; }
		protected override void OnStateEnter() => 
			_audioMixer.SetFloat(_volumeExposedParameter, VolumeLevel);
	}
}