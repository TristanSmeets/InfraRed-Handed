using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIndicator : MonoBehaviour
{
	Text scoreText;
	ScoreTracker scoreTracker;
	uint currentScore;
	uint newScore;

	// Start is called before the first frame update
	void Start()
    {
		scoreText = GetComponentInChildren<Text>();
		scoreText.text = string.Format("0");
		scoreTracker = FindObjectOfType<ScoreTracker>();
		scoreTracker.OnScoreChanged += onScoreChanged;
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
    }

	void onScoreChanged(uint score)
	{
		newScore = score;
	}

	public void ChangeScore()
	{
		StopAllCoroutines();
		StartCoroutine(increaseScore());
	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		currentScore = 0;
		scoreText.text = currentScore.ToString();
	}

	private void OnDestroy()
	{
		scoreTracker.OnScoreChanged -= onScoreChanged;
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}

	IEnumerator increaseScore()
	{
		while (currentScore < newScore)
		{
			scoreText.text = (currentScore++).ToString();
			yield return null;
		}
		currentScore = newScore;
		scoreText.text = currentScore.ToString();
	}
}
