using Alarm;

namespace AI
{
	public class MoveToAlarmState : BaseState
	{
		IRAlarm currentAlarm;
		AbstractAlarm currentAbstractAlarm;

		public MoveToAlarmState(Guard guard) : base(guard)
		{
		}

		public override void Enter()
		{
			if (owner.GuardIndicator != null)
				owner.GuardIndicator.SetIndicatorSprite(owner.GuardIndicator.GetIndicatorSprite(GeneralVariables.GUARD_ICON.QUESTION_MARK));

			StateVariables stateVariables = owner.FSM.GetStateVariables<MoveToAlarmState>();
			owner.LightFeedback.SetColour(stateVariables.GetLightColour());
			owner.VisionCone.SetMaterialColour(stateVariables.GetLightColour());
			agent.speed = stateVariables.GetMovementSpeed();
		}

		public override void Exit()
		{
		}

		public override void Update()
		{
			if (!agent.pathPending && agent.remainingDistance < owner.GuardRadius)
			{
				removeAlarm();
				owner.FSM.AlarmStateSwitch(owner.CurrentAlarmState);
			}
		}

		private void removeAlarm()
		{
			if (currentAbstractAlarm is IRAlarm)
				(currentAbstractAlarm as IRAlarm).SetIsTriggered(false);
			owner.RemoveAbstractAlarm(currentAbstractAlarm);
		}

		public void SetCurrentAbstractAlarm(AbstractAlarm alarm)
		{
			currentAbstractAlarm = alarm;
			agent.SetDestination(currentAbstractAlarm.transform.position);
		}

		public AbstractAlarm GetCurrentAbstractAlarm()
		{
			return currentAbstractAlarm;
		}
	}
}
