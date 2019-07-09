using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionConeFeedback : MonoBehaviour
{
	public GameObject VisionCone;
	Material material;

    // Start is called before the first frame update
    void Awake()
    {
		material = VisionCone.GetComponent<Renderer>().material;
    }

	public void SetMaterialColour(Color newColour)
	{
		material.color = newColour;
	}

	private void OnDestroy()
	{
	}
}
