using UnityEngine;

namespace AI
{
	public class IdleState : BaseState
	{
		public IdleState(Guard guard) : base(guard) { }

		public override void Enter()
		{
			setMovingAnimation(false);
			agent.destination = owner.Home;
			if (owner.GuardIndicator != null)
				owner.GuardIndicator.SetIndicatorSprite(owner.GuardIndicator.GetIndicatorSprite(GeneralVariables.GUARD_ICON.DOTS));

			StateVariables stateVariables = owner.FSM.GetStateVariables<IdleState>();
			owner.LightFeedback.SetColour(stateVariables.GetLightColour());
			owner.VisionCone.SetMaterialColour(stateVariables.GetLightColour());
			agent.speed = stateVariables.GetMovementSpeed();
		}

		public override void Exit()
		{
			setMovingAnimation(true);
		}

		public override void Update()
		{
		}

		void setMovingAnimation(bool isMoving)
		{
			Animator guardAnimator = owner.GetComponentInChildren<Animator>();
			guardAnimator.SetBool("isMoving", isMoving);
		}
	}
}
