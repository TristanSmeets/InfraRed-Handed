using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourBlinkAnimation : AbstractColourAnimation
{
	public float BlinkSpeed = 2;
	float blinkSpeed = 6.28f;

	protected override void Start()
	{
		base.Start();
		blinkSpeed = BlinkSpeed * Mathf.PI;
	}

	public override void PlayAnimation()
	{
		StopAllCoroutines();
		Func<float, float> easeFunction = blinkEaseFunction;
		StartCoroutine(playAnimation(easeFunction));
	}

	float blinkEaseFunction(float value)
	{
		return Mathf.Abs(Mathf.Sin(value * blinkSpeed));
	}
}
