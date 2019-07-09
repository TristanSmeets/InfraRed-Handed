using UnityEngine;

public class AlarmTriggeredSound : MonoBehaviour
{
	SoundEffect soundEffect;

	// Start is called before the first frame update
	void Start()
	{
		soundEffect = FindObjectOfType<SoundEffectManager>().GetSoundEffect(GeneralVariables.SFX.ALARM_TRIGGERED);
		AlarmTriggered.AddListener(onAlarmTriggered);
		CameraTriggered.AddListener(onCameraTriggered);
	}

	void onAlarmTriggered(AlarmTriggered alarmTriggered)
	{
		playSoundEffect();
	}

	private void playSoundEffect()
	{
		AudioSourceManager.PlayAudioOneShot(soundEffect.GetAudioClip(),
					soundEffect.GetVolume(),
					soundEffect.GetPitch(),
					soundEffect.GetSpatialBlend());
	}

	void onCameraTriggered(CameraTriggered cameraTriggered)
	{
		playSoundEffect();
	}

	private void OnDestroy()
	{
		AlarmTriggered.RemoveListener(onAlarmTriggered);
		CameraTriggered.RemoveListener(onCameraTriggered);
	}
}
