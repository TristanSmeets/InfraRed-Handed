using System;
using UnityEngine;

namespace Language
{
	[Serializable]
	public class ResolutionText : LanguageText
	{
		public enum COMPLETION { FAILURE, SUCCESS }
		[SerializeField] COMPLETION completion = COMPLETION.FAILURE;

		public ResolutionText(string text) : base(text)
		{
		}

		public COMPLETION GetIsSuccessful()
		{
			return completion;
		}
	}
}
