using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
	TextSetup[] textSetups;
	Text loadingText;
	Image bgImage;
	ComicImageManager imageManager;

	private void Awake()
	{
		loadingText = GetComponentInChildren<Text>();
		textSetups = GetComponentsInChildren<TextSetup>();
		bgImage = GetComponentInChildren<Image>();
		imageManager = GetComponentInChildren<ComicImageManager>();
		imageManager.gameObject.SetActive(false);
	}

	public void TextSetupsActivation(bool value)
	{
		for (int index = 0; index < textSetups.Length; index++)
		{
			textSetups[index].gameObject.SetActive(value);
		}
	}

	public Text GetLoadingText()
	{
		return loadingText;
	}

	public Image GetBGImage()
	{
		return bgImage;
	}

	public void PlayComicAnimation()
	{
		imageManager.gameObject.SetActive(true);
		imageManager.PlayAnimations();
		GetComponent<ColourEaseAnimation>().PlayAnimation();
	}
}
