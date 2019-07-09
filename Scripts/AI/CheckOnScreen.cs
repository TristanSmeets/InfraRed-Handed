using UnityEngine;

public class CheckOnScreen : MonoBehaviour
{
	GuardAggro guardAggro;
	Collider objectCollider;
	Camera mainCamera;
	GuardIndicatorManager indicatorManager;
	AI.Guard guard;
	// Start is called before the first frame update
	void Start()
	{
		guard = GetComponent<AI.Guard>();
		indicatorManager = FindObjectOfType<GuardIndicatorManager>();
		guardAggro = GetComponent<GuardAggro>();
		objectCollider = GetComponent<Collider>();
		mainCamera = Camera.main;
		mainCamera.GetComponent<FollowCamera>().OnFrustrumMoved += onFrustrumMoved;
	}

	void onFrustrumMoved(Plane[] planes)
	{
		if (GeometryUtility.TestPlanesAABB(planes, objectCollider.bounds))
		{
			if (!guardAggro.enabled)
				guardAggro.enabled = true;
			if (guard.GuardIndicator == null)
				setIndicator(true);
		}
		else
		{
			if (guardAggro.enabled)
				guardAggro.enabled = false;
			if (guard.GuardIndicator != null)
				setIndicator(false);
		}
	}

	void setIndicator(bool value)
	{
		GuardIndicator indicator = guard.GuardIndicator;

		switch (value)
		{
			case true:
				guard.GuardIndicator = indicatorManager.GetUnusedGuardIndicator();
				guard.GuardIndicator.InUse = value;
				guard.GuardIndicator.IndicatorLocation = guard.IndicatorLocation;
				break;
			case false:
				guard.GuardIndicator.InUse = value;
				guard.GuardIndicator.IndicatorLocation = null;
				guard.GuardIndicator.MoveOffScreen();
				guard.GuardIndicator = null;
				break;
		}
	}
}
