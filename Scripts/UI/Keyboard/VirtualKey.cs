using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VirtualKey : MonoBehaviour
{
	[SerializeField] SoundEffect soundEffect;
	int inputLimit = 0;
	Text textField;
	string key;
	[SerializeField] int fontSize = 60;
	Text buttonText;
	ScaleAnimation scaleAnimation;
	AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
		key = gameObject.name;
		buttonText = GetComponentInChildren<Text>();
		scaleAnimation = GetComponent<ScaleAnimation>();
		audioSource = GetComponent<AudioSource>();
		buttonText.text = key;
		buttonText.fontSize = fontSize;
    }

	public void SetTextField(Text text)
	{
		textField = text;
	}

	public void SetInputLimit(int limit)
	{
		inputLimit = limit;
	}

	public void AddLetterToTextField()
	{
		scaleAnimation.PlayAnimation();
		audioSource.PlayOneShot(soundEffect.GetAudioClip(), soundEffect.GetVolume());

		if (textField.text.Length < inputLimit)
		{
			textField.text += key;
		}
	}
}
