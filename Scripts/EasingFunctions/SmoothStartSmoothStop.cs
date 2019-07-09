using UnityEngine;

namespace EasingTristan
{
	public static class SmoothStartSmoothStop
	{
		//EaseInEaseOut functions
		public static float SmoothStart2SmoothStop2(float t)
		{
			return Mathf.Lerp(SmoothStart.SmoothStart2(t), SmoothStop.SmoothStop2(t), t);
		}

		public static float SmoothStart3SmoothStop2(float t)
		{
			return Mathf.Lerp(SmoothStart.SmoothStart3(t), SmoothStop.SmoothStop2(t), t);
		}

		public static float SmoothStart4SmoothStop2(float t)
		{
			return Mathf.Lerp(SmoothStart.SmoothStart4(t), SmoothStop.SmoothStop2(t), t);
		}

		public static float SmoothStart5SmoothStop2(float t)
		{
			return Mathf.Lerp(SmoothStart.SmoothStart5(t), SmoothStop.SmoothStop2(t), t);
		}
	}
}
