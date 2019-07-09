using System;
using UnityEngine;

namespace Language
{
	[Serializable]	
	public abstract class LanguageText
	{
		[SerializeField] protected string text;

		public LanguageText(string text)
		{
			this.text = text;
		}

		public virtual string GetText()
		{
			return text;
		}
	}
}
