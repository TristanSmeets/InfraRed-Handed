using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
	Text loadingText;
	LoadingScreenManager loadingScreenManager;
	public GameObject LoadingScreenPrefab;
	bool calledComicAnimation = false;

	public void LoadSceneNoButton(string sceneName)
	{
		createLoadingScreen();
		StartCoroutine(LoadSceneNoButtonpress(sceneName));
	}

	public void LoadSceneButtonPress(string sceneName)
	{
		createLoadingScreen();
		LoadingScreenPrefab.SetActive(true);
		StartCoroutine(LoadSceneButtonPressActivation(sceneName));
	}

	IEnumerator LoadSceneNoButtonpress(string sceneName)
	{
		if (Time.timeScale == 0)
			Time.timeScale = 1;
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
		string LoadingProgressString = Language.LanguageLocator.GetLanguage().GetLoadingText(Language.LoadingText.LOADING_TYPE.LOADING);
		while (!asyncLoad.isDone)
		{
			loadingText.text = LoadingProgressString + string.Format("\t{0}%", (int)(asyncLoad.progress * 100));
			yield return null;
		}
	}

	IEnumerator LoadSceneButtonPressActivation(string sceneName)
	{
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
		asyncOperation.allowSceneActivation = false;
		if (Time.timeScale == 0)
			Time.timeScale = 1;

		string LoadingProgressString = Language.LanguageLocator.GetLanguage().GetLoadingText(Language.LoadingText.LOADING_TYPE.LOADING);
		string LoadingCompletedString = Language.LanguageLocator.GetLanguage().GetLoadingText(Language.LoadingText.LOADING_TYPE.TOUCH);

		while (!asyncOperation.isDone)
		{
			loadingText.text = LoadingProgressString + string.Format("\t{0}%", (int)(asyncOperation.progress * 100));
			if (asyncOperation.progress >= 0.9f)
			{
				if (!calledComicAnimation)
				{
					loadingScreenManager.TextSetupsActivation(false);
					loadingScreenManager.PlayComicAnimation();
					calledComicAnimation = true;
				}
				loadingText.text = LoadingCompletedString;
				if (Input.GetMouseButtonDown(0))
					asyncOperation.allowSceneActivation = true;
			}
			yield return null;
		}
	}

	void createLoadingScreen()
	{
		GameObject NewLoadingScreen = Instantiate(LoadingScreenPrefab, GameObject.Find("Canvas").transform);
		loadingScreenManager = NewLoadingScreen.GetComponent<LoadingScreenManager>();
		loadingText = loadingScreenManager.GetLoadingText();
	}
}
