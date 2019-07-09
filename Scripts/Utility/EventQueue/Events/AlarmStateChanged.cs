using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventQueue;

public class AlarmStateChanged : GameEvent<AlarmStateChanged>
{
	public readonly GeneralVariables.ALARMSTATE AlarmState;
	public readonly Color StateColour;

	public AlarmStateChanged(GeneralVariables.ALARMSTATE alarmState, Color stateColour)
	{
		AlarmState = alarmState;
		StateColour = stateColour;
	}

	public override void NotifyListeners()
	{
		listeners?.Invoke(this);
	}
}
