using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BellShakeAnimation : AbstractEaseAnimation
{
	public float BlinkSpeed = 2;
	float blinkSpeed;
	[SerializeField] protected Image image;
	[SerializeField] protected Vector3 shakeRotation;
	[SerializeField] protected float startupTime;
	[SerializeField] protected float recoveryTime;
	protected Quaternion normalRotation;
	protected Quaternion normalShake;
	protected Quaternion negNormalShake;


	protected virtual void Start()
	{
		normalRotation = transform.rotation;
		if (image == null) image = GetComponent<Image>();
		blinkSpeed = (float)Math.PI * BlinkSpeed;
		normalShake = Quaternion.Euler(shakeRotation);
		negNormalShake = Quaternion.Euler(-shakeRotation);
	}

	public override void PlayAnimation()
	{
		StopAllCoroutines();
		Func<float, float> easeFunc = shakeEaseFunction;
		StartCoroutine(playAnimation(easeFunc));
	}

	protected override IEnumerator playAnimation(Func<float, float> easeFunction)
	{
		float elapsedTime = 0;

		while (elapsedTime < startupTime)
		{
			image.transform.rotation = Quaternion.Lerp(normalRotation, normalShake, easeFunction(elapsedTime / startupTime));
			yield return null;
			elapsedTime += Time.deltaTime;
		}

		elapsedTime = 0;

		while (elapsedTime < duration)
		{
			image.transform.rotation = Quaternion.Lerp(normalShake, negNormalShake, easeFunction(elapsedTime / duration));
			yield return null;
			elapsedTime += Time.deltaTime;
		}

		elapsedTime = 0;
		Quaternion currentRotation = image.transform.rotation;

		while (image.transform.rotation != normalRotation)
		{
			image.transform.rotation = Quaternion.Lerp(currentRotation, normalRotation, easeFunction(elapsedTime));
			yield return null;
			elapsedTime += Time.deltaTime;
		}
	}

	float shakeEaseFunction(float value)
	{
		return Mathf.Abs(Mathf.Sin((value + 0.5f) * blinkSpeed));
		//return Mathf.Abs(Mathf.Sin(value * blinkSpeed));
		//return Mathf.Round(Mathf.Abs(Mathf.Sin(value * blinkSpeed)));
	}
}
