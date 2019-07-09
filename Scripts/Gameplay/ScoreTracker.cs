using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
	uint currentScore = 0;
	public event Action<uint> OnScoreChanged = delegate { };
    // Start is called before the first frame update
    void Start()
    {
		CollectablePickedupEvent.AddListener(onCollectablePickedup);
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
    }

	void onCollectablePickedup(CollectablePickedupEvent collectablePickedup)
	{
		currentScore += collectablePickedup.Collectable.GetItemValue();
		OnScoreChanged(currentScore);
	}

	public uint GetCurrentScore()
	{
		return currentScore;
	}

	public void SaveCurrentScore()
	{
		PlayerPrefs.SetInt(GeneralVariables.PlayerScore, (int)currentScore);
	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		currentScore = 0;
		//OnScoreChanged(currentScore);
	}

	private void OnDestroy()
	{
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}
}
