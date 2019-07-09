using AI;
using UnityEngine;

namespace Alarm
{
	public class AlarmReducer : MonoBehaviour
	{
		[SerializeField] float reductionValue = .1f;
		[SerializeField] float timeBetweenReductions = 0.2f;
		[SerializeField] Guard[] guards;
		AlarmTracker tracker;
		float counter = 0;

		// Start is called before the first frame update
		void Start()
		{
			guards = GameObject.FindObjectsOfType(typeof(Guard)) as Guard[];
			tracker = GetComponent<AlarmTracker>();
		}

		// Update is called once per frame
		void Update()
		{
			if (areGuardsIdleOrGoingHome() && tracker.GetCurrentAlarmLevel() > 0)
			{
				counter += Time.deltaTime;
				if (counter > timeBetweenReductions)
				{
					tracker.ReduceAlarmLevel(reductionValue);
					counter = 0;
				}
			}
		}

		bool areGuardsIdleOrGoingHome()
		{
			for (int index = 0; index < guards.Length; index++)
			{
				if (!guards[index].FSM.GetGuardIdle())
				{
					return false;
				}
			}
			return true;
		}
	}
}