using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Language
{
	[Serializable]
	public class DialogueText : LanguageText
	{
		public enum DIALOGUE_TYPE { SPRAY, START, YARN }

		[SerializeField] DIALOGUE_TYPE dialogueType = DIALOGUE_TYPE.SPRAY;

		public DialogueText(string text) : base(text)
		{
		}

		public DIALOGUE_TYPE GetDialogueType()
		{
			return dialogueType;
		}
	}
}
