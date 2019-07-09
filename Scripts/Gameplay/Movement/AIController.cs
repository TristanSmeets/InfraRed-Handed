using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
	Animator animator;
	NavMeshAgent agent;
	PatrolPathManager pathManager;
	int currentLocation = 0;
	Vector3 startLocation;

	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		animator = GetComponentInChildren<Animator>();
		pathManager = GetComponent<PatrolPathManager>();
	}

	// Start is called before the first frame update
	void Start()
    {
		startLocation = agent.transform.position;
		agent.destination = pathManager.GetNextLocation(currentLocation);
		animator.SetFloat("Speed", agent.speed);
	}

    // Update is called once per frame
    void Update()
    {
		if (!agent.pathPending && agent.remainingDistance < agent.radius)
		{
			agent.destination = goToNextPoint();
		}
    }

	Vector3 goToNextPoint()
	{
		currentLocation = (currentLocation + 1) % pathManager.GetPatrolPathLength();
		if (currentLocation == 0)
			agent.Warp(startLocation);
		return pathManager.GetNextLocation(currentLocation);
	}
}
