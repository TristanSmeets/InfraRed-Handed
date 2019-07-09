using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SoundEffect
{
	[SerializeField] GeneralVariables.SFX sfxType;
	[SerializeField] AudioClip audioClip;
	[SerializeField] float volume, pitch, spatialBlend;

	public SoundEffect(GeneralVariables.SFX sfxType, AudioClip audioClip, float volume, float pitch, float spatialBlend)
	{
		this.sfxType = sfxType;
		this.audioClip = audioClip;
		this.volume = volume;
		this.pitch = pitch;
		this.spatialBlend = spatialBlend;
	}

	public AudioClip GetAudioClip() { return audioClip; }
	public float GetVolume() { return volume; }
	public float GetPitch() { return pitch; }
	public float GetSpatialBlend() { return spatialBlend; }
	public GeneralVariables.SFX GetSFXType() { return sfxType; }
}
