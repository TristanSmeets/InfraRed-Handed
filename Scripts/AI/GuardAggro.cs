using UnityEngine;
using AI;

public class GuardAggro : MonoBehaviour
{
	[SerializeField] float fieldOfView = 60;
	[SerializeField] float gameOverRange = 5;
	[SerializeField] float viewDistance = 50;
	Guard guard;
	GameObject player;
	bool seesPlayer;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindGameObjectWithTag(GeneralVariables.PlayerTag);
		guard = GetComponent<Guard>();
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
	}

	// Update is called once per frame
	void Update()
	{
		guardRangeCheck();
	}

	void guardRangeCheck()
	{
		RaycastHit hit;

		Vector3 direction = (player.transform.position - transform.position).normalized;

		if (Physics.Raycast(transform.position, direction, out hit, viewDistance) &&
			Vector3.Angle(direction, transform.forward) < (fieldOfView * 0.5f))
		{
			//Debug.DrawRay(transform.position, direction * viewDistance, Color.red);
			if (hit.collider.gameObject.tag == GeneralVariables.PlayerTag)
			{
				guard.FSM.ChangeState<ChasePlayerState>();

				if (hit.distance < gameOverRange && !seesPlayer)
				{
					seesPlayer = true;
					EventQueue.EventManager.Queue(new GameOverEvent());
				}
			}
		}
		else
		{
			if (guard.FSM.GetCurrentState().GetType() == typeof(ChasePlayerState))
				guard.FSM.AlarmStateSwitch(guard.CurrentAlarmState);
		}
	}

	public void SetAggroDistance(float value)
	{
		gameOverRange = value;
	}

	public float GetAggroDistance()
	{
		return gameOverRange;
	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		seesPlayer = false;
	}

	private void OnDestroy()
	{
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}
}
