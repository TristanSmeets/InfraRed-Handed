using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alarm
{
	[RequireComponent(typeof(AlarmIncreaser))]
	public abstract class AbstractAlarm : MonoBehaviour
	{
		protected static uint ID = 0;
		protected uint alarmID;
		protected AlarmIncreaser increaser;
		protected bool checkingCollisions = true;
		
		// Start is called before the first frame update
		protected virtual void Start()
		{
			gameObject.layer = LayerMask.NameToLayer("Alarm");
			ID++;
			alarmID = ID;
			increaser = GetComponent<AlarmIncreaser>();
		}

		public uint GetAlarmID()
		{
			return alarmID;
		}

		public void SetCheckingCollisions(bool value)
		{
			checkingCollisions = value;
		}
		public bool GetCheckingCollisions()
		{
			return checkingCollisions;
		}
	}
}
