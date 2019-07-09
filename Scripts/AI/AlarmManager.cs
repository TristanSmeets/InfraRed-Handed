using Alarm;
using System;
using UnityEngine;

namespace AI
{
	public class AlarmManager : MonoBehaviour
	{
		public IRAlarm[] Alarms;
		public event Action<IRAlarm> AlarmActivated = delegate { };

		// Start is called before the first frame update
		void Start()
		{
			//Listen to AlarmTriggered events.
			AlarmTriggered.AddListener(onAlarmTriggered);
		}

		void onAlarmTriggered(AlarmTriggered alarmTriggered)
		{
			IRAlarm triggeredAlarm = alarmTriggered.Alarm.GetComponent<IRAlarm>();
			for (int index = 0; index < Alarms.Length; index++)
			{
				if (triggeredAlarm == Alarms[index])
					AlarmActivated(triggeredAlarm);
			}
		}

		private void OnDestroy()
		{
			AlarmTriggered.RemoveListener(onAlarmTriggered);
		}
	}
}