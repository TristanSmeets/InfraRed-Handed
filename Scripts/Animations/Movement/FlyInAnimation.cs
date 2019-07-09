using System.Collections;
using UnityEngine;
using EasingTristan;
using System;
using UnityEngine.Events;

public class FlyInAnimation : AbstractMoveAnimation
{
	// Use this for initialization
	protected void Awake()
	{
		endPosition = transform.position; 
	}

	public override void PlayAnimation()
	{
		StopAllCoroutines();
		Func<float, float> easeFunc = SmoothStartSmoothStop.SmoothStart2SmoothStop2;
		StartCoroutine(playAnimation(easeFunc));
	}
}