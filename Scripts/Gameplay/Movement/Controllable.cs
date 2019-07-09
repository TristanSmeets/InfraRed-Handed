using UnityEngine;

public class Controllable : MonoBehaviour
{
	[SerializeField] float maxDistance = 10;
	[SerializeField] float maxSpeed = 10;
	float moveSpeed;
	CharacterController controller;
	Vector3 direction = Vector3.zero;

	private void Awake()
	{
		if (!GetComponent<CharacterController>())
			controller = gameObject.AddComponent<CharacterController>();
		else
			controller = GetComponent<CharacterController>();

		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
	}

	private void Start()
	{
		onLoadCheckpoint(FindObjectOfType<CheckpointManager>().GetActiveCheckpoint());
	}

	public void TapStartPosition(Vector2 position)
	{
	}

	public void TapMove(Vector2 newDirection)
	{
		direction = new Vector3(newDirection.x, 0, newDirection.y).normalized;
		float magnitude = newDirection.magnitude;
		newDirection.Normalize();
		moveSpeed = Mathf.Clamp(EasingTristan.SmoothStart.SmoothStart2(magnitude / maxDistance), 0, maxSpeed);
		Quaternion rotation = Quaternion.LookRotation(direction);
		transform.rotation = rotation;
	}

	public void TapEnd()
	{
		direction = Vector3.zero;
		moveSpeed = 0;
	}

	private void FixedUpdate()
	{
		controller.SimpleMove(direction * moveSpeed);
	}

	public float GetMoveSpeed()
	{
		return moveSpeed;
	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		controller.enabled = false;
		Vector3 startLocation = new Vector3(checkpoint.transform.position.x, gameObject.transform.position.y, checkpoint.transform.position.z);
		controller.transform.position = startLocation;
		controller.enabled = true;
	}

	private void OnDestroy()
	{
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}
}
