using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventQueue;
using Alarm;

public class CameraTriggered : GameEvent<CameraTriggered>
{
	public readonly SecurityCamera SecurityCamera;

	public CameraTriggered(SecurityCamera triggeredCamera)
	{
		SecurityCamera = triggeredCamera;
	}

	public override void NotifyListeners()
	{
		listeners?.Invoke(this);
	}
}
