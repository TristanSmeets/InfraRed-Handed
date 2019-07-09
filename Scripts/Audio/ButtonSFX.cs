using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSFX : MonoBehaviour
{
	[SerializeField] SoundEffect soundEffect;

	public void PlayButtonSound()
	{
		AudioSourceManager.PlayAudioOneShot(soundEffect.GetAudioClip(), soundEffect.GetVolume(),
			soundEffect.GetPitch(), soundEffect.GetSpatialBlend());
	}
}
