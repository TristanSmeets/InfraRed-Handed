using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSound : MonoBehaviour
{
	SoundEffect collectableSFX;
    // Start is called before the first frame update
    void Start()
    {
		collectableSFX = FindObjectOfType<SoundEffectManager>().GetSoundEffect(GeneralVariables.SFX.COLLECTABLE);
		CollectablePickedupEvent.AddListener(onCollectablePickedup);
    }

	void onCollectablePickedup(CollectablePickedupEvent collectablePickedup)
	{
		AudioSourceManager.PlayAudioOneShot(collectableSFX.GetAudioClip(),
			collectableSFX.GetVolume(),
			collectableSFX.GetPitch(),
			collectableSFX.GetSpatialBlend());
	}

	private void OnDestroy()
	{
		CollectablePickedupEvent.RemoveListener(onCollectablePickedup);
	}
}
