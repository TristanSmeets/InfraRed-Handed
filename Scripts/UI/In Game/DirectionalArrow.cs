using Movement;
using UnityEngine;
using UnityEngine.UI;

public class DirectionalArrow : MonoBehaviour
{
	Image arrowImage;
	UserInput userInput;

	// Start is called before the first frame update
	void Start()
	{
		userInput = FindObjectOfType<UserInput>();
		arrowImage = GetComponent<Image>();
		arrowImage.enabled = false;
		userInput.OnTapMove += onTapMove;
		userInput.OnTapEnd += onTapEnd;
	}

	void onTapMove(Vector2 direction)
	{
		if (arrowImage.enabled != true)
			arrowImage.enabled = true;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		arrowImage.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		arrowImage.transform.position = Input.mousePosition;
	}

	void onTapEnd()
	{
		arrowImage.enabled = false;
	}

	private void OnDestroy()
	{
		userInput.OnTapMove -= onTapMove;
		userInput.OnTapEnd -= onTapEnd;
	}
}
