using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardLightFeedback : MonoBehaviour
{
	Light spotLight;
    // Start is called before the first frame update
    void Awake()
    {
		spotLight = GetComponentInChildren<Light>();
    }

	public void SetColour(Color newColour)
	{
		spotLight.color = newColour;
	}

	public Color GetCurrentColour()
	{
		return spotLight.color;
	}
	private void OnDestroy()
	{
	}
}
