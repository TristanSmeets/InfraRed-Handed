using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardIndicatorManager : MonoBehaviour
{
	List<GuardIndicator> guardIndicators = new List<GuardIndicator>();
	Transform hudCanvas;
	public GameObject GuardIndicatorPrefab;
	Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
		mainCamera = Camera.main;
		hudCanvas = FindObjectOfType<Canvas>().gameObject.transform;
    }

	public GuardIndicator GetUnusedGuardIndicator()
	{
		for (int index = 0; index < guardIndicators.Count; index++)
		{
			if (!guardIndicators[index].InUse)
				return guardIndicators[index];
		}
		return createNewGuardIndicator();
	}

	GuardIndicator createNewGuardIndicator()
	{
		GameObject newGuardIndicator = Instantiate(GuardIndicatorPrefab,new Vector3(-Screen.width,- Screen.height, 0) , Quaternion.Euler(0,0,0), hudCanvas);
		GuardIndicator guardIndicator = newGuardIndicator.GetComponent<GuardIndicator>();
		guardIndicators.Add(guardIndicator);
		return guardIndicator;
	}
}
