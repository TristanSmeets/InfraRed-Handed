using System;
using UnityEngine;

namespace Alarm
{
	public class AlarmTracker : MonoBehaviour
	{
		[SerializeField] float currentAlarmlevel = 0;
		GeneralVariables.ALARMSTATE currentAlarmState = GeneralVariables.ALARMSTATE.NONE;
		[SerializeField] float lowThreshold = 1.0f, highTreshold = 2.0f, gameoverThreshold = 3.0f;
		[SerializeField] Color normalColour = Color.white, lowColour = Color.green, highColour = Color.red, fullColour = Color.blue;
		public event Action<float> OnAlarmLevelIncrease = delegate { };
		public event Action<float> OnAlarmLevelDecrease = delegate { };

		private void Start()
		{
			ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
		}

		private void Update()
		{
			checkAlarmLevel();
		}
		public void IncreaseAlarmLevel(float value)
		{
			currentAlarmlevel += value;
			OnAlarmLevelIncrease(currentAlarmlevel);
		}

		public void ReduceAlarmLevel(float value)
		{
			currentAlarmlevel -= value;
			if (currentAlarmlevel >= 0)
				OnAlarmLevelDecrease(currentAlarmlevel);
			else
			{
				currentAlarmlevel = 0;
				OnAlarmLevelDecrease(currentAlarmlevel);
			}
		}

		void checkAlarmLevel()
		{
			GeneralVariables.ALARMSTATE level;
			Color newColour;
			if (currentAlarmlevel >= gameoverThreshold)
			{
				level = GeneralVariables.ALARMSTATE.FULL;
				newColour = fullColour;
			}
			else if (currentAlarmlevel >= highTreshold)
			{
				level = GeneralVariables.ALARMSTATE.HIGH;
				newColour = highColour;
			}
			else if (currentAlarmlevel >= lowThreshold)
			{
				level = GeneralVariables.ALARMSTATE.LOW;
				newColour = lowColour;
			}
			else
			{
				level = GeneralVariables.ALARMSTATE.NONE;
				newColour = normalColour;
			}
			if (currentAlarmState != level)
			{
				currentAlarmState = level;
				EventQueue.EventManager.Queue(new AlarmStateChanged(currentAlarmState, newColour));
			}
		}

		public GeneralVariables.ALARMSTATE GetCurentAlarmState()
		{
			return currentAlarmState;
		}

		public float GetCurrentAlarmLevel()
		{
			return currentAlarmlevel;
		}

		void onLoadCheckpoint(Checkpoint checkpoint)
		{
			currentAlarmlevel = 0;
			checkAlarmLevel();
		}

		public Color GetNormalColour()
		{
			return normalColour;
		}

		private void OnDestroy()
		{
			ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
		}
	}
}
