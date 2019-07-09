using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextMovementAnimation : AbstractMoveAnimation
{
	bool inUse = false;
	Text scoreText;
	[SerializeField] Vector3 offscreen = new Vector3(-Screen.width, -Screen.height, 0);
	ScoreIndicator scoreIndicator;
	private void Awake()
	{
		transform.position = startPosition;
		scoreText = GetComponent<Text>();
		scoreIndicator = FindObjectOfType<ScoreIndicator>();
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
	}

	public override void PlayAnimation()
	{
		inUse = true;
		StopAllCoroutines();
		Func<float, float> easeFunc = EasingTristan.SmoothStart.SmoothStart4;
		StartCoroutine(playAnimation(easeFunc));
	}

	protected override IEnumerator playAnimation(Func<float, float> easeFunction)
	{
		float elapsedTime = 0;

		while (elapsedTime < duration)
		{
			transform.position = Vector3.Lerp(startPosition, endPosition, easeFunction(elapsedTime / duration));
			yield return null;
			elapsedTime += Time.deltaTime;
		}
		transform.position = offscreen;
		inUse = false;
		scoreIndicator.ChangeScore();
	}

	public void SetScoreText(string text)
	{
		scoreText.text = text;
	}

	public bool GetInUse()
	{
		return inUse;
	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		StopAllCoroutines();
		inUse = false;
		transform.position = offscreen;
	}

	private void OnDestroy()
	{
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}
}
