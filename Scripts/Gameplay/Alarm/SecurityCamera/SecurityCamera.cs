using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Alarm
{
	[RequireComponent(typeof(GuardTrigger))]
	public class SecurityCamera : AbstractAlarm
	{
		GuardTrigger guardTrigger;
		[SerializeField] float countdownResetTime = 2.0f;

		// Start is called before the first frame update
		protected override void Start()
		{
			base.Start();
			guardTrigger = GetComponent<GuardTrigger>();
		}

		void OnTriggerStay(Collider other)
		{
			if (other.tag == GeneralVariables.PlayerTag && checkingCollisions)
			{
				increaser.ContinualIncrease();
				guardTrigger.GuardCountdown();
			}
		}

		void OnTriggerExit(Collider other)
		{
			if (other.tag == GeneralVariables.PlayerTag)
			{
				//Stop the old Coroutine in case the player keeps entering and leaving the trigger.
				StopAllCoroutines();
				//Start new Coroutine.
				StartCoroutine(countdownResetTimer());
			}
		}

		///Used to reset the countdown back to 0
		///Resets after the player left the security camera's view for a time.
		IEnumerator countdownResetTimer()
		{
			float elapsedTime = 0.0f;

			while (elapsedTime < countdownResetTime)
			{
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			increaser.ResetCountdown();
			guardTrigger.ResetGuardTrigger();
		}
	}
}