using UnityEngine;

namespace AI
{
	public class LookForPlayerState : BaseState
	{
		LocationsToCheck locations;
		Vector3 currentDestination;
		int locationsChecked;

		public LookForPlayerState(Guard guard) : base(guard)
		{
		}

		public override void Enter()
		{
			locations = owner.GetComponent<LocationsToCheck>();
			Vector3 newLocation = locations.GetLocationCloseToPlayer();
			currentDestination = newLocation;
			agent.SetDestination(currentDestination);
			locationsChecked = 1;
			if (owner.GuardIndicator != null)
				owner.GuardIndicator.SetIndicatorSprite(owner.GuardIndicator.GetIndicatorSprite(GeneralVariables.GUARD_ICON.QUESTION_MARK));

			StateVariables stateVariables = owner.FSM.GetStateVariables<LookForPlayerState>();
			owner.LightFeedback.SetColour(stateVariables.GetLightColour());
			owner.VisionCone.SetMaterialColour(stateVariables.GetLightColour());
			agent.speed = stateVariables.GetMovementSpeed();
		}

		public override void Exit()
		{
		}

		public override void Update()
		{
			if (GeneralVariables.AmountOfLocationsToCheck > locationsChecked)
			{
				//Check if guard is close to a location. If so start moving to next location.
				if (!agent.pathPending && agent.remainingDistance < 0.5f)
				{
					goToNextPoint();
					locationsChecked++;
				}
			}
			else
			{
				if (!agent.pathPending && agent.remainingDistance < owner.GuardRadius)
				{
					if (owner.IsPatrolling)
						owner.FSM.ChangeState<PatrolState>();
					else
						owner.FSM.ChangeState<GoingHomeState>();
				}
			}
		}

		void goToNextPoint()
		{
			Vector3 nextDestination = locations.GetLocationCloseToPlayer();
			if (nextDestination == currentDestination)
			{
				nextDestination = locations.GetRandomLocation();
				currentDestination = nextDestination;
				agent.SetDestination(currentDestination);
			}
			else
			{
				currentDestination = nextDestination;
				agent.SetDestination(currentDestination);
			}
		}
	}
}
