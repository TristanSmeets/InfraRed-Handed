using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasingTristan;

public class ShaderFadeOut : MonoBehaviour
{
	[SerializeField] float fadeOutTime = 1.0f;
	Material material;

    // Start is called before the first frame update
    void Start()
    {
		material = GetComponent<Renderer>().material;
    }

	public void StartFadeOut()
	{
		StopAllCoroutines();
		StartCoroutine(transparencyFadeOut());
	}

	IEnumerator transparencyFadeOut()
	{
		float elapsedTime = 0;
		material.SetFloat(GeneralVariables.ShaderTransparency, 1);

		while (elapsedTime + Mathf.Epsilon < fadeOutTime)
		{
			material.SetFloat(GeneralVariables.ShaderTransparency, Mathf.Lerp(1, 0, SmoothStart.SmoothStart2(elapsedTime / fadeOutTime)));
			yield return null;
			elapsedTime += Time.deltaTime;
		}
		material.SetFloat(GeneralVariables.ShaderTransparency, 0);
	}
}
