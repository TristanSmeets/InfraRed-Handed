using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Movement;

public class ActivityChecker : MonoBehaviour
{
	SceneLoader sceneLoader;
	InputProvider inputProvider;
	public string sceneToLoad = "MainMenu";
	[SerializeField] float countdownTime = 30.0f;
	// Start is called before the first frame update

	private void Awake()
	{
		sceneLoader = FindObjectOfType<SceneLoader>();
		inputProvider = GetComponent<InputProvider>();
	}
	void Start()
	{
		inputProvider.OnTapStart += onTapStart;
		inputProvider.OnTapMove += onTapMove;
		inputProvider.OnTapEnd += onTapEnd;
	}

	void onTapStart(Vector2 position)
	{
		StopAllCoroutines();
	}

	void onTapMove(Vector2 direction)
	{
	}

	void onTapEnd()
	{
		StartCoroutine(startCountdown());
	}

	IEnumerator startCountdown()
	{
		float elapsedTime = 0;
		while (elapsedTime < countdownTime)
		{
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		sceneLoader.LoadSceneNoButton(sceneToLoad);
	}
}
