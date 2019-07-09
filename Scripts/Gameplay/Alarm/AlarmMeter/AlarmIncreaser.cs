using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alarm
{
	public class AlarmIncreaser : MonoBehaviour
	{
		[SerializeField] float increase = .25f;
		[SerializeField] float timeBetweenIncreases = 1.0f;

		AlarmTracker tracker;
		float countdown;
		// Start is called before the first frame update
		void Start()
		{
			tracker = FindObjectOfType(typeof(AlarmTracker)) as AlarmTracker;
		}

		/// <summary>
		/// Continuously increases the notoriety after a specific time passed.
		/// </summary>
		public void ContinualIncrease()
		{
			countdown += Time.deltaTime;
			if (countdown > timeBetweenIncreases)
			{
				Increase();
				countdown = 0.0f;
			}
		}

		/// <summary>
		/// Increases the Player's notoriety.
		/// Uses the value specified in the NotorietyIncreaser.
		/// </summary>
		public void Increase()
		{
			tracker.IncreaseAlarmLevel(increase);
		}

		public void ResetCountdown()
		{
			countdown = 0;
		}
	}
}
