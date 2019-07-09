using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alarm;

namespace AI
{
	public class LocationsToCheck : MonoBehaviour
	{
		public GameObject LocationsGroup;
		Location[] Locations;
		GameObject target;

		private void Start()
		{
			target = GameObject.FindGameObjectWithTag(GeneralVariables.PlayerTag);
			if (LocationsGroup != null)
				Locations = LocationsGroup.GetComponentsInChildren<Location>();
		}

		public Vector3 GetRandomLocation()
		{
			int randomNumber = Random.Range(0, Locations.Length);
			return Locations[randomNumber].gameObject.transform.position;
		}

		public Vector3 GetLocationCloseToPlayer()
		{
			Vector3 newLocation = Vector3.zero;
			float distance = 0;
			for (int index = 0; index < Locations.Length; index++)
			{

				float distance2 = (target.transform.position - Locations[index].gameObject.transform.position).sqrMagnitude;
				if (distance == 0 || distance2 < distance)
				{
					distance = distance2;
					newLocation = Locations[index].gameObject.transform.position;
				}
			}
			return newLocation;
		}
	}
}
