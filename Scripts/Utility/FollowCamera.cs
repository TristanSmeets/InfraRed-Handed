using EasingTristan;
using Movement;
using System;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
	public Vector3 Offset;
	[SerializeField] float maxViewDistance = 10;
	[SerializeField] float maxDistance = 10;
	[Range(0.0f, 0.1f)]
	public float SmoothSpeed;
	Transform target;
	Vector3 playerDirection;
	UserInput userInput;
	Camera mainCamera;
	bool isMoving;
	Vector3 oldPosition;
	Vector3 newPosition;

	public event Action<Plane[]> OnFrustrumMoved = delegate { };

	// Start is called before the first frame update
	void Start()
	{
		GameObject player = GameObject.FindGameObjectWithTag(GeneralVariables.PlayerTag);
		target = player.transform;

		mainCamera = GetComponent<Camera>();

		gameObject.transform.position = target.position + Offset;

		//Hooking up the camera to UserInput so the camera can move in the direction the player is moving.
		userInput = player.GetComponent<UserInput>();
		userInput.OnTapStart += onTouchStart;
		userInput.OnTapMove += onPlayerMoves;
		userInput.OnTapEnd += onTouchEnd;

		//Hooking up to ResolutionSetup.OnLevelLoad to move camera on checkpoint loading
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		oldPosition = transform.position;
		newPosition = Vector3.Lerp(transform.position, target.position + Offset + playerDirection, SmoothSpeed);
		transform.position = newPosition;
	}

	private void LateUpdate()
	{
		if (newPosition != oldPosition)
		{
			OnFrustrumMoved(GeometryUtility.CalculateFrustumPlanes(mainCamera));
		}
	}

	void onTouchStart(Vector2 position)
	{
	}

	void onPlayerMoves(Vector2 direction)
	{
		Vector2 normalizedDirection = direction.normalized;
		float magnitude = direction.magnitude;
		float viewDistance = Mathf.Clamp(SmoothStart.SmoothStart2(magnitude / maxDistance), 0, maxViewDistance);
		playerDirection = new Vector3(normalizedDirection.x, 0, normalizedDirection.y) * viewDistance;
	}

	void onTouchEnd()
	{
		playerDirection = Vector2.zero;
	}

	private void OnDestroy()
	{
		//Decouple functions from UserInput in case camera gets destroyed but player remains.
		userInput.OnTapMove -= onPlayerMoves;
		userInput.OnTapEnd -= onTouchEnd;

		//Decouple function from ResolutionScreen
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;

		OnFrustrumMoved = null;

	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		gameObject.transform.position = target.position + Offset;
	}
}
