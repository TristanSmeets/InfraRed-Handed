using Alarm;
using UnityEngine;

public class ActivitySwitcher : MonoBehaviour
{
	[SerializeField] float timeBetweenChange = 1.0f;
	Renderer meshRenderer;
	AbstractAlarm abstractAlarm;
	[SerializeField] float startingOffset = 0.0f;
	float elapsedTime = 0;
	bool currentVisibility = true;

	// Start is called before the first frame update
	void Start()
	{
		Random.InitState(GetInstanceID());
		abstractAlarm = GetComponent<AbstractAlarm>();
		meshRenderer = GetComponent<Renderer>();
		elapsedTime = Random.value * startingOffset;
	}

	// Update is called once per frame
	void Update()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime > timeBetweenChange)
		{
			currentVisibility = !currentVisibility;
			switchObjectVisibility(currentVisibility);
			elapsedTime = 0.0f;
		}
	}

	void switchObjectVisibility(bool value)
	{
		meshRenderer.enabled = value;
		abstractAlarm.SetCheckingCollisions(value);
	}
}
