using UnityEngine;

public class ResolutionScreenTrigger : MonoBehaviour
{
#pragma warning disable 0649
	[SerializeField] GameObject resolutionScreen;
	[SerializeField] GameObject hud;
#pragma warning restore 0649
	bool showingResolution = false;

	GameObject newResolutionScreen;

	void Start()
	{
		Time.timeScale = 1;
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
	}

	public void GameOver(bool isCompleted)
	{
		if (!showingResolution)
		{
			showingResolution = true;
			hud.SetActive(false);
			createResolutionScreen(isCompleted);
			Time.timeScale = 0;
		}
	}

	private void createResolutionScreen(bool isCompleted)
	{
		newResolutionScreen = Instantiate(resolutionScreen, hud.transform.parent);
		ResolutionScreenSetup screenSetup = newResolutionScreen.GetComponent<ResolutionScreenSetup>();
		screenSetup.SetupResolutionScreen(isCompleted);
	}

	private void OnDestroy()
	{
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		Destroy(newResolutionScreen);
		hud.SetActive(true);
		showingResolution = false;
		Time.timeScale = 1;
	}
}
