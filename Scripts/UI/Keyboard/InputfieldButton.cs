using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InputfieldButton : MonoBehaviour
{
	public GameObject VirtualKeyboard;
	[SerializeField] int inputLimit = 10;
	VirtualKey[] virtualKeys;
	Text textField;
	bool gotSelected = false;
	public static event Action OnInputfieldSelected = delegate { };

    // Start is called before the first frame update
    void Start()
    {
		virtualKeys = VirtualKeyboard.GetComponentsInChildren<VirtualKey>();
		VirtualKeyboard.SetActive(false);
		textField = GetComponentInChildren<Text>();
    }

	public void InputfieldSelected()
	{
		gotSelected = true;
		VirtualKeyboard.SetActive(true);
		textField.text = "";
		for (int index = 0; index < virtualKeys.Length; index++)
		{
			virtualKeys[index].SetTextField(textField);
			virtualKeys[index].SetInputLimit(inputLimit);
		}
		OnInputfieldSelected();
	}

	public Text GetTextfield()
	{
		return textField;
	}

	public bool GotSelected
	{
		get { return gotSelected; }
	}
}
