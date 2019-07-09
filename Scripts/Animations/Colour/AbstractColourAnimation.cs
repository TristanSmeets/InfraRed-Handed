using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractColourAnimation : AbstractEaseAnimation
{
	protected Color normalColour = Color.white;
	[SerializeField] protected Color animationColour = Color.red;
	[SerializeField] protected Image image;

    protected virtual void Start()
    {
		if (image == null) image = GetComponent<Image>();
		normalColour = image.color;
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
		image.color = normalColour;
	}

	public void SetNormalColour(Color newColour)
	{
		normalColour = newColour;
	}

	public void SetAnimationColour(Color newColour)
	{
		animationColour = newColour;
	}

	public void ResetImageColour(Color newColour)
	{
		normalColour = newColour;
		image.color = normalColour;
	}
}
