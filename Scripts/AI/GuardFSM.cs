using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
	[RequireComponent(typeof(Guard))]
	public class GuardFSM : MonoBehaviour
	{
		[SerializeField] StateVariables idle = new StateVariables(Color.white, 6.0f);

		[SerializeField] StateVariables moveToHome = new StateVariables(Color.grey, 6.0f);
		[SerializeField] StateVariables moveToAlarm = new StateVariables(Color.red, 6.0f);
		[SerializeField] StateVariables scanArea = new StateVariables(Color.green, 6.0f);
		[SerializeField] StateVariables lookForPlayer = new StateVariables(Color.yellow, 6.0f);
		[SerializeField] StateVariables patrol = new StateVariables(Color.blue, 6.0f);
		[SerializeField] StateVariables chasePlayer = new StateVariables(Color.cyan, 6.0f);

		Dictionary<Type, BaseState> stateCache = new Dictionary<Type, BaseState>();
		Dictionary<Type, StateVariables> stateVariablesCache = new Dictionary<Type, StateVariables>();
		BaseState currentState;
		Guard owner;

		// Start is called before the first frame update
		void Awake()
		{
			owner = GetComponent<Guard>();
			stateCache.Add(typeof(MoveToAlarmState), new MoveToAlarmState(owner));
			stateCache.Add(typeof(IdleState), new IdleState(owner));
			stateCache.Add(typeof(GoingHomeState), new GoingHomeState(owner));
			stateCache.Add(typeof(ScanAreaState), new ScanAreaState(owner));
			stateCache.Add(typeof(LookForPlayerState), new LookForPlayerState(owner));
			stateCache.Add(typeof(PatrolState), new PatrolState(owner));
			stateCache.Add(typeof(ChasePlayerState), new ChasePlayerState(owner));

			stateVariablesCache.Add(typeof(MoveToAlarmState), moveToAlarm);
			stateVariablesCache.Add(typeof(IdleState), idle);
			stateVariablesCache.Add(typeof(GoingHomeState), moveToHome);
			stateVariablesCache.Add(typeof(ScanAreaState), scanArea);
			stateVariablesCache.Add(typeof(LookForPlayerState), lookForPlayer);
			stateVariablesCache.Add(typeof(PatrolState), patrol);
			stateVariablesCache.Add(typeof(ChasePlayerState), chasePlayer);
		}

		void Update()
		{
			currentState?.Update();
		}

		public BaseState GetCurrentState()
		{
			return currentState;
		}

		public void ChangeState<T>() where T : BaseState
		{
			BaseState newState = stateCache[typeof(T)];
			changeState(newState);
		}

		private void changeState(BaseState newState)
		{
			if (currentState == newState) return;
			currentState?.Exit();
			currentState = newState;
			currentState?.Enter();
		}

		public StateVariables GetStateVariables<T>() where T : BaseState
		{
			return stateVariablesCache[typeof(T)];
		}

		public bool GetGuardIdle()
		{
			return (GetCurrentState().GetType() == typeof(IdleState) ||
				GetCurrentState().GetType() == typeof(GoingHomeState) ||
				GetCurrentState().GetType() == typeof(PatrolState));
		}

		public void AlarmStateSwitch(GeneralVariables.ALARMSTATE alarmState)
		{
			if (owner.ActiveAlarmsCount > 0)
			{
				ChangeState<MoveToAlarmState>();
				(GetCurrentState() as MoveToAlarmState).SetCurrentAbstractAlarm(owner.GetActiveAlarm(owner.ActiveAlarmsCount - 1));
				return;
			}

			switch (alarmState)
			{
				case GeneralVariables.ALARMSTATE.NONE:
					ChangeState<GoingHomeState>();
					break;
				case GeneralVariables.ALARMSTATE.LOW:
					ChangeState<ScanAreaState>();
					break;
				case GeneralVariables.ALARMSTATE.HIGH:
					ChangeState<LookForPlayerState>();
					break;
				case GeneralVariables.ALARMSTATE.FULL:
					ChangeState<LookForPlayerState>();
					break;
				default:
					ChangeState<IdleState>();
					break;
			}
		}
	}
}
