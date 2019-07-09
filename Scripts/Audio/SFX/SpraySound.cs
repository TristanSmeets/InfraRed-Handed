using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpraySound : MonoBehaviour
{
	SoundEffect sprayFull;
	SoundEffect sprayEmpty;
	Spray.SprayActivation sprayActivation;

    // Start is called before the first frame update
    void Awake()
    {
		sprayActivation = FindObjectOfType<Spray.SprayActivation>();
		sprayActivation.OnFullSprayActivation += playFullSound;
		sprayActivation.OnEmptySprayActivation += playEmptySound;
    }

	private void Start()
	{
		SoundEffectManager effectManager = FindObjectOfType<SoundEffectManager>();
		sprayFull = effectManager.GetSoundEffect(GeneralVariables.SFX.SPRAY_FULL);
		sprayEmpty = effectManager.GetSoundEffect(GeneralVariables.SFX.SPRAY_EMPTY);
	}

	void playFullSound()
	{
		AudioSourceManager.PlayAudioOneShot(sprayFull.GetAudioClip(),
			sprayFull.GetVolume(),
			sprayFull.GetPitch(),
			sprayFull.GetSpatialBlend());
	}

	void playEmptySound()
	{
		AudioSourceManager.PlayAudioOneShot(sprayEmpty.GetAudioClip(),
			sprayEmpty.GetVolume(),
			sprayEmpty.GetPitch(),
			sprayEmpty.GetSpatialBlend());
	}

	private void OnDestroy()
	{
		sprayActivation.OnEmptySprayActivation -= playEmptySound;
		sprayActivation.OnFullSprayActivation -= playFullSound;
	}
}
