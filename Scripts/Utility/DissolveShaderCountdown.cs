using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasingTristan;

public class DissolveShaderCountdown : MonoBehaviour
{
	[SerializeField] float countdownTime = 1;
	[SerializeField] float dissolveTime = 1;
	float count = 0;
	Material material;

	private void Start()
	{
		material = GetComponent<Renderer>().material;
		setShaderMin(0);
	}

	private void Update()
	{
		if (count > countdownTime)
		{
			StartCoroutine(dissolveParticles());
			count = 0;
		}
		count += Time.deltaTime;
	}

	void setShaderMin(float value)
	{
		material.SetFloat("_Min", value);
	}

	IEnumerator dissolveParticles()
	{
		float elapsedTime = 0;
		setShaderMin(0);
		while (elapsedTime < countdownTime)
		{
			setShaderMin(Mathf.Lerp(0, 1, SmoothStart.SmoothStart2(elapsedTime / dissolveTime)));
			yield return null;
			elapsedTime += Time.deltaTime;
		}
		setShaderMin(1);
	}
}
