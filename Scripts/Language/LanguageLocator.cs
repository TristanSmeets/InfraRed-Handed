using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Language
{
	public static class LanguageLocator
	{
		static LanguageObject language;

		public static void SetLanguague(LanguageObject value)
		{
			language = value;
		}

		public static LanguageObject GetLanguage()
		{
			return language;
		}
	}
}
