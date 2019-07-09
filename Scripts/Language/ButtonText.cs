using System;
using UnityEngine;

namespace Language
{
	[Serializable]
	public class ButtonText : LanguageText
	{
		public enum BUTTON_TYPE
		{
			AGE_INPUT, AGE_TEXT, BACK, CREDITS, EXIT,
			LEADERBOARD, LOAD_CHECKPOINT, NAME_INPUT,
			NAME_TEXT, RESTART_LEVEL, START, FEEDBACK
		}

		[SerializeField] BUTTON_TYPE buttonType = BUTTON_TYPE.START;

		public ButtonText(string text) : base(text)
		{
		}

		public BUTTON_TYPE GetButtonType()
		{
			return buttonType;
		}
	}
}
