using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Alarm;

public class AlertBar : MonoBehaviour
{
	public float VisibleTime = 2f;
	ColourBlinkAnimation blinkAnimation;
	public Image bgImage;
	public Text alertText;
	AlarmTracker tracker;

    // Start is called before the first frame update
    void Start()
    {
		changeUIState(false);
		tracker = GameObject.FindObjectOfType<AlarmTracker>();
		tracker.OnAlarmLevelIncrease += onAlarmLevelIncrease;
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
		blinkAnimation = GetComponent<ColourBlinkAnimation>();
    }

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		changeUIState(false);
	}

	void onAlarmLevelIncrease(float value)
	{
		changeUIState(true);
		blinkAnimation.PlayAnimation();
		StartCoroutine(hideUIAfterTime());
	}

	void changeUIState(bool visibility)
	{
		bgImage.enabled = visibility;
		alertText.enabled = visibility;
	}

	private void OnDestroy()
	{
		tracker.OnAlarmLevelIncrease -= onAlarmLevelIncrease;
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}

	IEnumerator hideUIAfterTime()
	{
		float elapsedTime = 0f;
		while (elapsedTime < VisibleTime)
		{
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		changeUIState(false);
	}
}
