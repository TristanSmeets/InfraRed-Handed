using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YarnTrigger : MonoBehaviour
{
	public GameObject Orb;
	public Material playerMaterial;
	public Shader NormalShader;
	public Shader ReplacementShader;
	ResolutionScreenTrigger resolutionScreenTrigger;
    // Start is called before the first frame update
    void Start()
    {
		resolutionScreenTrigger = FindObjectOfType<ResolutionScreenTrigger>();
		Orb.SetActive(false);
		playerMaterial = GameObject.FindGameObjectWithTag(GeneralVariables.PlayerTag).GetComponentInChildren<Renderer>().material;
		playerMaterial.shader = NormalShader;
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
	}

	public void FreezeTime()
	{
		Time.timeScale = 0;
		playerMaterial.shader = ReplacementShader;
	}
	public void ShowOrb()
	{
		Orb.SetActive(true);
	}

	public void TriggerResolutionScreen(int complete)
	{
		switch (complete)
		{
			case 0:
				resolutionScreenTrigger.GameOver(false);
				break;
			case 1:
				resolutionScreenTrigger.GameOver(true);
				break;
		}
	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		playerMaterial.shader = NormalShader;
	}

	private void OnDestroy()
	{
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}
}
