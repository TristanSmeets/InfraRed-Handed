namespace AI
{
	public class GoingHomeState : BaseState
	{
		public GoingHomeState(Guard guard) : base(guard)
		{
		}

		public override void Enter()
		{
			agent.SetDestination(owner.Home);
			if (owner.GuardIndicator != null)
				owner.GuardIndicator.SetIndicatorSprite(owner.GuardIndicator.GetIndicatorSprite(GeneralVariables.GUARD_ICON.DOTS));

			StateVariables stateVariables = owner.FSM.GetStateVariables<GoingHomeState>();
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
				if (owner.IsPatrolling)
					owner.FSM.ChangeState<PatrolState>();
				else
					owner.FSM.ChangeState<IdleState>();
			}
		}
	}
}
