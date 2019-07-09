using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMoveAnimation : AbstractEaseAnimation
{
	protected Vector3 startPosition;
	protected Vector3 endPosition;

	public Vector3 StartPosition
	{
		get { return startPosition; }
		set { startPosition = value; }
	}

	public Vector3 EndPosition
	{
		get { return endPosition; }
		set { endPosition = value; }
	}

	protected override IEnumerator playAnimation(Func<float, float> easeFunction)
	{
		float elapsedTime = 0;
		while (elapsedTime < duration)
		{
			transform.position = Vector3.Lerp(startPosition, endPosition, easeFunction(elapsedTime / duration));
			yield return null;
			elapsedTime += Time.unscaledDeltaTime;
			//elapsedTime += GeneralVariables.FixedTimeStep;
		}
		transform.position = endPosition;
	}
}
