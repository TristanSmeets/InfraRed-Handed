using System;
using UnityEngine;

namespace AI
{
	public class PatrolState : BaseState
	{
		PatrolPathManager path;
		int currentLocation = 0;
		public PatrolState(Guard guard) : base(guard)
		{
		}

		public override void Enter()
		{
			path = owner.GetComponent<PatrolPathManager>();
			agent.destination = path.GetNextLocation(currentLocation);
			if (owner.GuardIndicator != null)
				owner.GuardIndicator.SetIndicatorSprite(owner.GuardIndicator.GetIndicatorSprite(GeneralVariables.GUARD_ICON.DOTS));

			StateVariables stateVariables = owner.FSM.GetStateVariables<PatrolState>();
			owner.LightFeedback.SetColour(stateVariables.GetLightColour());
			owner.VisionCone.SetMaterialColour(stateVariables.GetLightColour());
			agent.speed = stateVariables.GetMovementSpeed();

			Animator animator = owner.GetComponentInChildren<Animator>();
			animator.SetBool("isMoving", true);
		}

		public override void Exit()
		{
		}

		public override void Update()
		{
			if (!agent.pathPending && agent.remainingDistance < owner.GuardRadius)
			{
				agent.destination = goToNextPoint();
			}
		}

		Vector3 goToNextPoint()
		{
			currentLocation = (currentLocation + 1) % path.GetPatrolPathLength();
			return path.GetNextLocation(currentLocation);
		}
	}
}
