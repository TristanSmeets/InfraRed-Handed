using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using EasingTristan;
using System;

public class ColourSpikeAnimation : AbstractColourAnimation
{
	public override void PlayAnimation()
	{
		StopAllCoroutines();
		Func<float, float> easeFunction = Spike.SmoothStartSpike2;
		StartCoroutine(playAnimation(easeFunction));
	}
}
