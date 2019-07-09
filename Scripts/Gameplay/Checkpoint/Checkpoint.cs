using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
	[SerializeField] bool isStart = false;
	public static event Action<Checkpoint> OnCheckpointTriggered = delegate { };

	public bool IsStart {
		get { return isStart; }
	}

	private void OnTriggerEnter(Collider other)
	{
		OnCheckpointTriggered(this);
	}
}
