using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
	Checkpoint[] checkpoints;
	Checkpoint activeCheckpoint;
	// Start is called before the first frame update
	void Awake()
	{
		checkpoints = FindObjectsOfType<Checkpoint>();
		Checkpoint.OnCheckpointTriggered += SetActiveCheckpoint;
		ResetStartLocation();
	}

	public Vector3 GetStartLocation()
	{
		return activeCheckpoint.transform.position;
	}

	public void SetActiveCheckpoint(Checkpoint checkpoint)
	{
		activeCheckpoint = checkpoint;
	}

	public Checkpoint GetActiveCheckpoint()
	{
		return activeCheckpoint;
	}

	public void ResetStartLocation()
	{
		for (int index = 0; index < checkpoints.Length; ++index)
		{
			if (checkpoints[index].IsStart)
				SetActiveCheckpoint(checkpoints[index]);
		}
	}

	private void OnDestroy()
	{
		Checkpoint.OnCheckpointTriggered -= SetActiveCheckpoint;
	}
}
