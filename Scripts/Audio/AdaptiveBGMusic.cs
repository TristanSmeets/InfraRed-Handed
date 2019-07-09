using EasingTristan;
using System.Collections;
using UnityEngine;

public class AdaptiveBGMusic : MonoBehaviour
{
	[SerializeField] AudioSource[] audioSources = new AudioSource[4];
	[SerializeField] float maxVolume = 1;
	[SerializeField] float crossfadeTime = 1;
	AudioSource currentAudioSource;
	GeneralVariables.ALARMSTATE currentAlarmState = GeneralVariables.ALARMSTATE.NONE;

	// Start is called before the first frame update
	void Start()
	{
		audioSources = GetComponents<AudioSource>();
		AlarmStateChanged.AddListener(onAlarmStateChanged);
		setVolumeAllAudioSources(0);
		currentAudioSource = audioSources[0];
		currentAudioSource.volume = maxVolume;
	}


	void setVolumeAllAudioSources(float volume)
	{
		for (int index = 0; index < audioSources.Length; ++index)
		{
			audioSources[index].volume = volume;
		}
	}

	void onAlarmStateChanged(AlarmStateChanged stateChanged)
	{
		if (currentAlarmState != stateChanged.AlarmState)
		{
			switch (stateChanged.AlarmState)
			{
				case GeneralVariables.ALARMSTATE.NONE:
					StartCoroutine(crossFadeTracks(currentAudioSource, audioSources[0]));
					currentAlarmState = stateChanged.AlarmState;
					break;
				case GeneralVariables.ALARMSTATE.LOW:
					StartCoroutine(crossFadeTracks(currentAudioSource, audioSources[1]));
					currentAlarmState = stateChanged.AlarmState;
					break;
				case GeneralVariables.ALARMSTATE.HIGH:
					StartCoroutine(crossFadeTracks(currentAudioSource, audioSources[2]));
					currentAlarmState = stateChanged.AlarmState;
					break;
				case GeneralVariables.ALARMSTATE.FULL:
					StartCoroutine(crossFadeTracks(currentAudioSource, audioSources[3]));
					currentAlarmState = stateChanged.AlarmState;
					break;
			}
		}
	}

	IEnumerator crossFadeTracks(AudioSource current, AudioSource target)
	{
		float elapsedTime = 0;
		while (elapsedTime < crossfadeTime)
		{
			current.volume = Mathf.Lerp(current.volume, 0, SmoothStartSmoothStop.SmoothStart2SmoothStop2(elapsedTime / crossfadeTime));
			target.volume = Mathf.Lerp(target.volume, maxVolume, SmoothStartSmoothStop.SmoothStart2SmoothStop2(elapsedTime / crossfadeTime));
			yield return null;
			elapsedTime += Time.deltaTime;
		}
		current.volume = 0;
		target.volume = maxVolume;
		currentAudioSource = target;
	}

	private void OnDestroy()
	{
		AlarmStateChanged.RemoveListener(onAlarmStateChanged);
	}
}
