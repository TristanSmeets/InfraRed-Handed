using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Language
{
	[Serializable]
	public class FeedbackText : LanguageText
	{
		public enum FEEDBACK_TYPE { AWARENESS, OPINION }
		[SerializeField] FEEDBACK_TYPE feedbackType = FEEDBACK_TYPE.AWARENESS;

		public FeedbackText(string text) : base(text)
		{
		}

		public FEEDBACK_TYPE GetFeedbackType()
		{
			return feedbackType;
		}
	}
}
