using UnityEngine;

namespace EasingTristan
{
	public static class Spike
	{
		public static float SmoothStartSpike2(float duration)
		{
			if (duration <= .5f)
			{
				return SmoothStart.SmoothStart2(duration / 0.5f);
			}
			return SmoothStart.SmoothStart2(GeneralEase.Flip(duration) / .5f);
		}
		public static float SmoothStopSpike2(float duration)
		{
			if (duration <= 0.5f)
				return SmoothStop.SmoothStop2(duration / 0.5f);
			else
				return SmoothStop.SmoothStop2(GeneralEase.Flip(duration) / 0.5f);
		}
	}
}
