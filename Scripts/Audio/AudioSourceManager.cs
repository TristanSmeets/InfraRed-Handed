using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceManager : MonoBehaviour
{
	static List<AudioSource> audioSources = new List<AudioSource>();
	static GameObject audioManager;

	private void Start()
	{
		audioManager = gameObject;
	}

	public static void PlayAudioOneShot(AudioClip audioClip, float volume = 1.0f, float pitch = 1.0f, float spatialBlend = 0.0f)
	{
		AudioSource FreshAudioSource = GetFreshAudioSource();
		FreshAudioSource.volume = volume;
		FreshAudioSource.pitch = pitch;
		FreshAudioSource.spatialBlend = spatialBlend;
		FreshAudioSource.PlayOneShot(audioClip);
	}

	public static AudioSource GetFreshAudioSource()
	{
		for (int index = 0; index < audioSources.Count; index++)
		{
			AudioSource FreshAudioSource = audioSources[index];

			if (!FreshAudioSource.isPlaying)
				return FreshAudioSource;
		}

		AudioSource NewAudioSource = audioManager.AddComponent<AudioSource>();
		audioSources.Add(NewAudioSource);
		return NewAudioSource;
	}

	private void OnDestroy()
	{
		audioSources.Clear();
	}
}
