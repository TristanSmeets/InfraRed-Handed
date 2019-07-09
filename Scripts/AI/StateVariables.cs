using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AI
{
	[Serializable]
	public struct StateVariables
	{
		[SerializeField] Color lightColour;
		[SerializeField] float movementSpeed;

		public StateVariables(Color colour, float speed)
		{
			lightColour = colour;
			movementSpeed = speed;
		}

		public Color GetLightColour()
		{
			return lightColour;
		}

		public float GetMovementSpeed()
		{
			return movementSpeed;
		}
	}
}
