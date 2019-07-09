using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGImageSetup : MonoBehaviour
{
	public Sprite[] bgSprites = new Sprite[2];
	Image bgImage;

	private void Awake()
	{
		bgImage = GetComponent<Image>();
	}

	public void SetBGImage(bool value)
	{
		if (value)
			bgImage.sprite = bgSprites[1];
		else
			bgImage.sprite = bgSprites[0];
	}
}
