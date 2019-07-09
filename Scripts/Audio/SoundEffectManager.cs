using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
	public SoundEffect[] SoundEffects;

	Dictionary<GeneralVariables.SFX, SoundEffect> sfxDictionary = new Dictionary<GeneralVariables.SFX, SoundEffect>();

    // Start is called before the first frame update
    void Awake()
    {
		for (int index = 0; index < SoundEffects.Length; index++)
		{
			sfxDictionary.Add(SoundEffects[index].GetSFXType(), SoundEffects[index]); 
		}
		
		//SoundEffects = null;
    }

	public SoundEffect GetSoundEffect(GeneralVariables.SFX soundEffect)
	{
		return sfxDictionary[soundEffect];
	}
}
