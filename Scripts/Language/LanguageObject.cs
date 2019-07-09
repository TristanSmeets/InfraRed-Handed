using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Language
{
	[CreateAssetMenu(menuName = "Language")]
	public class LanguageObject : ScriptableObject
	{
		[SerializeField] string alertText = "";
		[SerializeField] ButtonText[] buttons = new ButtonText[(int)ButtonText.BUTTON_TYPE.FEEDBACK + 1];
		[SerializeField] DialogueText[] dialogues = new DialogueText[(int)DialogueText.DIALOGUE_TYPE.YARN + 1];
		[SerializeField] FeedbackText[] feedbackTexts = new FeedbackText[(int)FeedbackText.FEEDBACK_TYPE.OPINION + 1];
		[SerializeField] LoadingText[] loadingTexts = new LoadingText[(int)LoadingText.LOADING_TYPE.TOUCH + 1];
		[SerializeField] ResolutionText[] resolutionTexts = new ResolutionText[(int)ResolutionText.COMPLETION.SUCCESS + 1];

		public string GetAlertText()
		{
			return alertText;
		}

		public string GetButtonText(ButtonText.BUTTON_TYPE buttonType)
		{
			for (int index = 0; index < buttons.Length; index++)
			{
				if (buttons[index].GetButtonType() == buttonType)
					return buttons[index].GetText();
			}

			return null;
		}

		public string GetDialogueText(DialogueText.DIALOGUE_TYPE dialogueType)
		{
			for (int index = 0; index < dialogues.Length; index++)
			{
				if (dialogues[index].GetDialogueType() == dialogueType)
					return dialogues[index].GetText();
			}

			return null;
		}

		public string GetLoadingText(LoadingText.LOADING_TYPE loadingType)
		{
			for (int index = 0; index < loadingTexts.Length; index++)
			{
				if (loadingTexts[index].GetLoadingType() == loadingType)
					return loadingTexts[index].GetText();
			}

			return null;
		}

		public string GetResolutionText(ResolutionText.COMPLETION completion)
		{
			for (int index = 0; index < resolutionTexts.Length; index++)
			{
				if (resolutionTexts[index].GetIsSuccessful() == completion)
					return resolutionTexts[index].GetText();
			}

			return null;
		}

		public string GetFeedbackText(FeedbackText.FEEDBACK_TYPE feedbackType)
		{
			for (int index = 0; index < feedbackTexts.Length; index++)
			{
				if (feedbackTexts[index].GetFeedbackType() == feedbackType)
					return feedbackTexts[index].GetText();
			}
			return null;
		}
	}
}
