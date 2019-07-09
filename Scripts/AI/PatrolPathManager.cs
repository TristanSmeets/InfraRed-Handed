using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPathManager : MonoBehaviour
{
#pragma warning disable 0649
	[SerializeField] Transform[] patrolLocations;
#pragma warning restore 0649

	public Vector3 GetNextLocation(int index)
	{
		return patrolLocations[index].position;
	}

	public int GetPatrolPathLength()
	{
		return patrolLocations.Length;
	}
}
