using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Language;

public class AssignLanguage : MonoBehaviour
{
	public LanguageObject[] Languages;
	public static event Action OnLanguageSet = delegate { };


	private void Awake()
	{
		LanguageLocator.SetLanguague(Languages[0]);
	}

	public void SetLanguage(int index)
	{
		LanguageLocator.SetLanguague(Languages[index]);
		OnLanguageSet();
	}
}
