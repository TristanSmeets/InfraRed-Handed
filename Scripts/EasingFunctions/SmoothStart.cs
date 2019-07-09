using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EasingTristan
{
	public static class SmoothStart
	{
		//EaseIn functions
		public static float SmoothStart2(float t)
		{
			return t * t;
		}

		public static float SmoothStart3(float t)
		{
			return t * t * t;
		}

		public static float SmoothStart4(float t)
		{
			return t * t * t * t;
		}

		public static float SmoothStart5(float t)
		{
			return t * t * t * t * t;
		}
	}
}