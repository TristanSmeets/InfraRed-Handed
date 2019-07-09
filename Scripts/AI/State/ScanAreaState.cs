using UnityEngine;

namespace AI
{
	public class ScanAreaState : BaseState
	{
		float rotationLeft;
		float rotationSpeed;

		public ScanAreaState(Guard guard) : base(guard)
		{
		}

		public override void Enter()
		{
			rotationLeft = 360.0f;
			rotationSpeed = GeneralVariables.GuardRotationSpeed;

			if (owner.GuardIndicator != null)
				owner.GuardIndicator.SetIndicatorSprite(owner.GuardIndicator.GetIndicatorSprite(GeneralVariables.GUARD_ICON.QUESTION_MARK));

			StateVariables stateVariables = owner.FSM.GetStateVariables<ScanAreaState>();
			owner.LightFeedback.SetColour(stateVariables.GetLightColour());
			owner.VisionCone.SetMaterialColour(stateVariables.GetLightColour());
			agent.speed = stateVariables.GetMovementSpeed();
		}

		public override void Exit()
		{
		}

		public override void Update()
		{
			rotateOwner();
		}

		void rotateOwner()
		{
			float frameRotation = rotationSpeed * Time.deltaTime;
			if (rotationLeft > frameRotation)
				rotationLeft -= frameRotation;
			else
			{
				frameRotation = rotationLeft;
				rotationLeft = 0;
				owner.transform.Rotate(Vector3.up, frameRotation);
				owner.FSM.ChangeState<GoingHomeState>();
			}
			owner.transform.Rotate(Vector3.up, frameRotation);
		}

		public void SetRotationSpeed(float value)
		{
			rotationSpeed = value;
		}

		public float GetRotationSpeed()
		{
			return rotationSpeed;
		}
	}
}
