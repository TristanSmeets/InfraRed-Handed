using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AcceptButton : MonoBehaviour
{
	public Text AgeTextField;
	public Text NameTextField;
	Text buttonText;
	SceneLoader sceneLoader;
	public string NextSceneName;

	InputfieldButton[] inputfields;

	private void Awake()
	{
		inputfields = FindObjectsOfType<InputfieldButton>();
		sceneLoader = GetComponent<SceneLoader>();
		buttonText = GetComponentInChildren<Text>();
		buttonText.gameObject.SetActive(false);
	}

	// Start is called before the first frame update
	void Start()
    {
		InputfieldButton.OnInputfieldSelected += onInputfieldSelected;
    }

	void onInputfieldSelected()
	{
		int differentFieldsSelected = 0;

		for (int index = 0; index < inputfields.Length; index++)
		{
			if (inputfields[index].GotSelected)
				differentFieldsSelected++;
		}

		if (differentFieldsSelected == inputfields.Length &&
			(NameTextField.text.Length > 0 || AgeTextField.text.Length > 0))
		{
			buttonText.gameObject.SetActive(true);
		}
	}

	public void SaveNameAndAge()
	{
		if (NameTextField.text.Length > 0 &&
			AgeTextField.text.Length > 0)
		{

			PlayerPrefs.SetString(GeneralVariables.PlayerName, NameTextField.text);
			if (int.TryParse(AgeTextField.text, out int age))
			{
				PlayerPrefs.SetInt(GeneralVariables.PlayerAge, age);
			}
			FindObjectOfType<EventSystem>().gameObject.SetActive(false);
			sceneLoader.LoadSceneButtonPress(NextSceneName);
		}
	}

	private void OnDestroy()
	{
		InputfieldButton.OnInputfieldSelected -= onInputfieldSelected;
	}
}
