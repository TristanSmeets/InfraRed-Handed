using AI;
using UnityEngine;
using UnityEngine.UI;

public class GuardIndicator : MonoBehaviour
{
	[SerializeField] Sprite[] stateIndicators = new Sprite[3];
	float interpolateDistance = 3000;
	public float distance2;
	Image currentImage;
	Camera mainCamera;
	public bool InUse { get; set; }
	Transform indicatorLocation;
	public Transform IndicatorLocation { set { indicatorLocation = value; } }
	// Start is called before the first frame update
	void Awake()
	{
		mainCamera = Camera.main;
		currentImage = GetComponent<Image>();
		SetIndicatorSprite(GetIndicatorSprite(GeneralVariables.GUARD_ICON.DOTS));
	}

	public void MoveOffScreen()
	{
		currentImage.transform.position = new Vector3(-Screen.width, -Screen.height, 0);
	}

	private void LateUpdate()
	{
		if (indicatorLocation != null)
		{
			currentImage.transform.position = mainCamera.WorldToScreenPoint(indicatorLocation.position);
			interpolateScale();
		}
	}

	public Sprite GetIndicatorSprite(GeneralVariables.GUARD_ICON icon)
	{
		return stateIndicators[(int)icon];
	}

	public void SetIndicatorSprite(Sprite sprite)
	{
		currentImage.sprite = sprite;
	}

	void interpolateScale()
	{
		distance2 = (mainCamera.transform.position - indicatorLocation.position).sqrMagnitude;
		currentImage.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, EasingTristan.SmoothStart.SmoothStart2(distance2 / interpolateDistance));
	}
}
