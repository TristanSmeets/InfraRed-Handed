using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AI;

public class ChasePlayerState : BaseState 
{
	Transform target;

	public ChasePlayerState(Guard guard) : base(guard)
	{
	}

	public override void Enter()
	{
		target = GameObject.FindGameObjectWithTag(GeneralVariables.PlayerTag).transform;
		if (owner.GuardIndicator != null)
			owner.GuardIndicator.SetIndicatorSprite(owner.GuardIndicator.GetIndicatorSprite(GeneralVariables.GUARD_ICON.EXCLAMATION));

		StateVariables stateVariables = owner.FSM.GetStateVariables<ChasePlayerState>();
		owner.LightFeedback.SetColour(stateVariables.GetLightColour());
		owner.VisionCone.SetMaterialColour(stateVariables.GetLightColour());
		agent.speed = stateVariables.GetMovementSpeed();
	}

	public override void Exit()
	{
	}

	public override void Update()
	{
		agent.destination = target.position;
	}
}
