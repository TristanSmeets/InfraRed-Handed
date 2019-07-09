using UnityEngine;
using System;

namespace EasingTristan
{
	public static class GeneralEase
	{
		public static float Flip(float t)
		{
			return 1 - t;
		}

		public static float Scale(Func<float, float> easeFunction, float t)
		{
			return t * easeFunction(t);
		}

		public static float ReverseScale(Func<float, float> easeFunction, float t)
		{
			return Flip(t) * easeFunction(t);
		}

		public static float AsymptoticAverage(float current, float target, float blend)
		{
			return (Flip(blend) * current) + (blend * target);
		}
	}
}
