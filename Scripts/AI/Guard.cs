using Alarm;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
	[RequireComponent(typeof(GuardFSM), typeof(AbstractAlarmManager))]
	public class Guard : MonoBehaviour
	{
		[SerializeField] bool isPatrolling = false;
		[SerializeField] float guardRadius = 0.5f;
#pragma warning disable 0649
		[SerializeField] Transform indicatorSpot;
#pragma warning restore 0649
		AbstractAlarmManager abstractAlarmManager;
		List<AbstractAlarm> activeAlarms = new List<AbstractAlarm>();
		public GeneralVariables.ALARMSTATE CurrentAlarmState { get; private set; } = GeneralVariables.ALARMSTATE.NONE;
		public Vector3 Home { get; private set; }
		public GuardFSM FSM { get; private set; }
		GuardIndicator guardIndicator;
		VisionConeFeedback visionCone;

		private void Awake()
		{
			abstractAlarmManager = GetComponent<AbstractAlarmManager>();
			FSM = GetComponent<GuardFSM>();
			Home = gameObject.transform.position;
			LightFeedback = GetComponent<GuardLightFeedback>();
			visionCone = GetComponent<VisionConeFeedback>();
		}

		// Start is called before the first frame update
		void Start()
		{
			if (isPatrolling)
				FSM.ChangeState<PatrolState>();
			else
				FSM.ChangeState<IdleState>();

			abstractAlarmManager.AbstractAlarmActivated += onAbstractAlarmActivated;
			AlarmStateChanged.AddListener(onAlarmStateChanged);
			ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
		}

		void onAlarmStateChanged(AlarmStateChanged alarmStateChanged)
		{
			if (CurrentAlarmState != alarmStateChanged.AlarmState)
				CurrentAlarmState = alarmStateChanged.AlarmState;
			if (CurrentAlarmState == GeneralVariables.ALARMSTATE.FULL)
				if (FSM.GetGuardIdle())
					FSM.AlarmStateSwitch(CurrentAlarmState);
		}

		void onAbstractAlarmActivated(AbstractAlarm abstractAlarm)
		{
			activeAlarms.Add(abstractAlarm);
			FSM.ChangeState<MoveToAlarmState>();
			(FSM.GetCurrentState() as MoveToAlarmState).SetCurrentAbstractAlarm(abstractAlarm);
		}

		void onLoadCheckpoint(Checkpoint checkpoint)
		{
			GetComponent<NavMeshAgent>().Warp(Home);
			if (isPatrolling)
				FSM.ChangeState<PatrolState>();
			else
				FSM.ChangeState<IdleState>();
		}

		public GuardIndicator GuardIndicator
		{
			get { return guardIndicator; }
			set
			{
				guardIndicator = value;
				if (value != null)
					guardIndicator.SetIndicatorSprite(guardIndicator.GetIndicatorSprite(getGuardIcon(FSM.GetCurrentState())));
			}
		}

		public VisionConeFeedback VisionCone { get { return visionCone; } }

		public GuardLightFeedback LightFeedback { get; private set; }
		public void RemoveAbstractAlarm(AbstractAlarm abstractAlarm)
		{
			if (activeAlarms.Contains(abstractAlarm))
				activeAlarms.Remove(abstractAlarm);
		}

		public int ActiveAlarmsCount { get { return activeAlarms.Count; } }

		public AbstractAlarm GetActiveAlarm(int index)
		{
			return activeAlarms[index];
		}

		private void OnDestroy()
		{
			AlarmStateChanged.RemoveListener(onAlarmStateChanged);
			ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
		}

		public bool IsPatrolling { get { return isPatrolling; } }

		public float GuardRadius { get { return guardRadius; } }

		public Transform IndicatorLocation { get { return indicatorSpot; } }

		GeneralVariables.GUARD_ICON getGuardIcon(BaseState baseState)
		{
			if (baseState is ChasePlayerState)
			{
				return GeneralVariables.GUARD_ICON.EXCLAMATION;
			}
			else if (baseState is MoveToAlarmState ||
				baseState is ScanAreaState ||
				baseState is LookForPlayerState)
				return GeneralVariables.GUARD_ICON.QUESTION_MARK;
			return GeneralVariables.GUARD_ICON.DOTS;
		}
	}
}
