using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourEaseAnimation : AbstractColourAnimation
{
	public override void PlayAnimation()
	{
		StopAllCoroutines();
		Func<float, float> easeFunc = EasingTristan.SmoothStop.SmoothStop2;
		StartCoroutine(playAnimation(easeFunc));
	}

	protected override IEnumerator playAnimation(Func<float, float> easeFunction)
	{
		float elapsedTime = 0;
		while (elapsedTime < duration)
		{
			image.color = Color.Lerp(normalColour, animationColour, easeFunction(elapsedTime / duration));
			yield return null;
			elapsedTime += Time.deltaTime;
		}
		image.color = animationColour;
		SetNormalColour(animationColour);
	}
}
