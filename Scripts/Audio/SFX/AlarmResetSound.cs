using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmResetSound : MonoBehaviour
{
	SoundEffect alarmResetSound;
	AudioSource audioSource;
	// Start is called before the first frame update
    void Start()
    {
		alarmResetSound = FindObjectOfType<SoundEffectManager>().GetSoundEffect(GeneralVariables.SFX.ALARM_RESET);
		audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.volume = alarmResetSound.GetVolume();
		audioSource.pitch = alarmResetSound.GetPitch();
		audioSource.spatialBlend = alarmResetSound.GetSpatialBlend();
    }

	public void PlayResetSound()
	{
		audioSource.PlayOneShot(alarmResetSound.GetAudioClip());
	}
}
