using EasingTristan;
using System;
using System.Collections;
using UnityEngine;

public class ScaleAnimation : AbstractEaseAnimation
{

	[SerializeField] Vector3 endScale = Vector3.one;
	Vector3 startScale;

	// Use this for initialization
	void Awake()
	{
		startScale = transform.localScale;
	}

	public Vector3 EndScale
	{
		get { return endScale; }
		set { endScale = value; }
	}

	protected override IEnumerator playAnimation(Func<float, float> easeFunction)
	{
		transform.localScale = startScale;
		float elapsedTime = 0;
		while (elapsedTime <= duration)
		{
			transform.localScale = Vector3.Lerp(startScale, endScale, easeFunction(elapsedTime / duration));
			yield return null;
			elapsedTime += Time.deltaTime;
		}
		transform.localScale = Vector3.Lerp(startScale, endScale, easeFunction(1));
	}

	public override void PlayAnimation()
	{
		StopAllCoroutines();
		Func<float, float> easeFunc = Spike.SmoothStartSpike2;
		StartCoroutine(playAnimation(easeFunc));
	}
}
