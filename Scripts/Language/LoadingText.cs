using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Language
{
	[Serializable]
	public class LoadingText : LanguageText
	{
		public enum LOADING_TYPE { COLLECT, GUARD, LASER, LOADING, TOUCH}
		[SerializeField] LOADING_TYPE loadingType = LOADING_TYPE.COLLECT;

		public LoadingText(string text) : base(text)
		{
		}

		public LOADING_TYPE GetLoadingType()
		{
			return loadingType;
		}
	}
}
