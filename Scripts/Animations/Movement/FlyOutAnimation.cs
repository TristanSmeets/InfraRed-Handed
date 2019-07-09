using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasingTristan;

public class FlyOutAnimation : AbstractMoveAnimation
{
    // Start is called before the first frame update
    void Awake()
    {
		startPosition = transform.position;
    }

	public override void PlayAnimation()
	{
		StopAllCoroutines();
		Func<float, float> easeFunc = SmoothStartSmoothStop.SmoothStart2SmoothStop2;
		StartCoroutine(playAnimation(easeFunc));
	}
}
