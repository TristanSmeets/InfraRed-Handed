using Language;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TextSetup : MonoBehaviour
{
	public enum TEXT_TYPE { ALERT, BUTTON, DIALOGUE, FEEDBACK, LOADING, RESOLUTION };

	public Text TextObject;
	public TEXT_TYPE TextType;
	public int enumIndex;
	//public UnityEvent TextFunction;

	LanguageObject currentLanguage;
	// Start is called before the first frame update
	void Start()
	{
		currentLanguage = LanguageLocator.GetLanguage();
		AssignLanguage.OnLanguageSet += onLanguageSet;
		onLanguageSet();
	}

	void onLanguageSet()
	{
		currentLanguage = LanguageLocator.GetLanguage();
		switch (TextType)
		{
			case TEXT_TYPE.ALERT:
				SetAlertText();
				break;
			case TEXT_TYPE.BUTTON:
				SetButtonText();
				break;
			case TEXT_TYPE.DIALOGUE:
				SetDialogueText();
				break;
			case TEXT_TYPE.FEEDBACK:
				SetFeedbackText();
				break;
			case TEXT_TYPE.LOADING:
				SetLoadingText();
				break;
			case TEXT_TYPE.RESOLUTION:
				SetResolutionText();
				break;
		}
	}

	public void SetAlertText()
	{
		setObjectText(currentLanguage.GetAlertText());
	}

	public void SetButtonText()
	{

		if (System.Enum.IsDefined(typeof(ButtonText.BUTTON_TYPE), enumIndex))
			setObjectText(currentLanguage.GetButtonText((ButtonText.BUTTON_TYPE)enumIndex));
	}

	public void SetDialogueText()
	{
		if (System.Enum.IsDefined(typeof(DialogueText.DIALOGUE_TYPE), enumIndex))
			setObjectText(currentLanguage.GetDialogueText((DialogueText.DIALOGUE_TYPE)enumIndex));
	}

	public void SetFeedbackText()
	{
		if (System.Enum.IsDefined(typeof(FeedbackText.FEEDBACK_TYPE), enumIndex))
			setObjectText(currentLanguage.GetFeedbackText((FeedbackText.FEEDBACK_TYPE)enumIndex));
	}

	public void SetLoadingText()
	{
		if (System.Enum.IsDefined(typeof(LoadingText.LOADING_TYPE), enumIndex))
			setObjectText(currentLanguage.GetLoadingText((LoadingText.LOADING_TYPE)enumIndex));
	}

	public void SetResolutionText()
	{
		if (System.Enum.IsDefined(typeof(ResolutionText.COMPLETION), enumIndex))
			setObjectText(currentLanguage.GetResolutionText((ResolutionText.COMPLETION)enumIndex));
	}

	void setObjectText(string message)
	{
		TextObject.text = message;
	}

	private void OnDestroy()
	{
		AssignLanguage.OnLanguageSet -= onLanguageSet;
	}
}
