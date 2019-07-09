using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverSound : MonoBehaviour
{
	SoundEffect gameOverSound;

    // Start is called before the first frame update
    void Start()
    {
		gameOverSound = GetComponent<SoundEffectManager>().GetSoundEffect(GeneralVariables.SFX.GAME_OVER);
		GameOverEvent.AddListener(onGameOver);
    }

	void onGameOver(GameOverEvent gameOverEvent)
	{
		if (!gameOverEvent.IsCompleted)
			AudioSourceManager.PlayAudioOneShot(
				gameOverSound.GetAudioClip(),
				gameOverSound.GetVolume(),
				gameOverSound.GetPitch(),
				gameOverSound.GetSpatialBlend());
	}

	private void OnDestroy()
	{
		GameOverEvent.RemoveListener(onGameOver);
	}
}
