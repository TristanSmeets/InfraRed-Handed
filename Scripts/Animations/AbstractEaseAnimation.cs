using System;
using System.Collections;
using UnityEngine;


public abstract class AbstractEaseAnimation : MonoBehaviour
{
	[SerializeField] protected float duration = 1.0f;

	public float Duration { get { return duration; } set { duration = value; } }

	public abstract void PlayAnimation();

	protected abstract IEnumerator playAnimation(Func<float, float> easeFunction);
}

