using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasingTristan
{
	public static class SmoothStop
	{
		//Ease out functions.

		public static float SmoothStop2(float t)
		{
			return GeneralEase.Flip(SmoothStart.SmoothStart2(GeneralEase.Flip(t)));
		}

		public static float SmoothStop3(float t)
		{
			return GeneralEase.Flip(SmoothStart.SmoothStart3(GeneralEase.Flip(t)));
		}

		public static float SmoothStop4(float t)
		{
			return GeneralEase.Flip(SmoothStart.SmoothStart4(GeneralEase.Flip(t)));
		}

		public static float SmoothStop5(float t)
		{
			return GeneralEase.Flip(SmoothStart.SmoothStart5(GeneralEase.Flip(t)));
		}
	}
}
