using Alarm;
using System;
using UnityEngine;

namespace AI
{
	public class AbstractAlarmManager : MonoBehaviour
	{
		public GameObject AlarmGroup;
		AbstractAlarm[] abstractAlarms;
		public event Action<AbstractAlarm> AbstractAlarmActivated = delegate { };
		// Start is called before the first frame update
		void Start()
		{
			if (AlarmGroup != null)
				abstractAlarms = AlarmGroup.GetComponentsInChildren<AbstractAlarm>();
			else
				abstractAlarms = new AbstractAlarm[0];
			AlarmTriggered.AddListener(onAlarmTriggered);
			CameraTriggered.AddListener(onCameraTriggered);
		}

		void onAlarmTriggered(AlarmTriggered alarmTriggered)
		{
			IRAlarm triggered = alarmTriggered.Alarm;

			for (int index = 0; index < abstractAlarms.Length; index++)
			{
				if (triggered.GetAlarmID() == abstractAlarms[index].GetAlarmID())
				{ 
					AbstractAlarmActivated(abstractAlarms[index]);
				}
			}
		}

		void onCameraTriggered(CameraTriggered cameraTriggered)
		{
			SecurityCamera securityCamera = cameraTriggered.SecurityCamera;

			for (int index = 0; index < abstractAlarms.Length; index++)
			{
				if (securityCamera.GetAlarmID() == abstractAlarms[index].GetAlarmID())
				{
					AbstractAlarmActivated(abstractAlarms[index]);
				}
			}
		}

		private void OnDestroy()
		{
			AlarmTriggered.RemoveListener(onAlarmTriggered);
			CameraTriggered.RemoveListener(onCameraTriggered);
		}
	}
}
