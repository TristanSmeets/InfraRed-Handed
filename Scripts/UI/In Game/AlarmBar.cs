using Alarm;
using EasingTristan;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AlarmBar : MonoBehaviour
{
	AlarmTracker tracker;
	[SerializeField] float increaseTime = 2f;

	Slider alarmSlider;
	ColourBlinkAnimation blinkAnimation;
	ColourSpikeAnimation spikeAnimation;
	ColourEaseAnimation bellColourAnimation;
	BellShakeAnimation bellShake;

	// Start is called before the first frame update
	void Start()
	{
		alarmSlider = GetComponent<Slider>();
		tracker = GameObject.FindObjectOfType<AlarmTracker>();
		blinkAnimation = GetComponent<ColourBlinkAnimation>();
		spikeAnimation = GetComponent<ColourSpikeAnimation>();
		bellShake = GetComponent<BellShakeAnimation>();
		bellColourAnimation = GetComponent<ColourEaseAnimation>();
		alarmSlider.value = 0;
		tracker.OnAlarmLevelIncrease += onAlarmLevelIncreased;
		tracker.OnAlarmLevelDecrease += onAlarmLevelDecreased;
		AlarmStateChanged.AddListener(onAlarmStateChanged);
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
	}

	void onAlarmStateChanged(AlarmStateChanged alarmStateChanged)
	{
		setAnimationNormalColour(alarmStateChanged.StateColour);
		bellColourAnimation.PlayAnimation();
	}

	void onAlarmLevelDecreased(float newValue)
	{
		alarmSlider.value = newValue;
		spikeAnimation.PlayAnimation();
	}

	void onAlarmLevelIncreased(float newValue)
	{
		StopAllCoroutines();
		StartCoroutine(increaseSlider(newValue));
		blinkAnimation.PlayAnimation();
		bellShake.PlayAnimation();
	}

	private void OnDestroy()
	{
		tracker.OnAlarmLevelIncrease -= onAlarmLevelIncreased;
		tracker.OnAlarmLevelDecrease -= onAlarmLevelDecreased;
		AlarmStateChanged.RemoveListener(onAlarmStateChanged);
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}

	IEnumerator increaseSlider(float newSliderValue)
	{
		float elapsedTime = 0f;
		while (elapsedTime < increaseTime)
		{
			alarmSlider.value = Mathf.Lerp(alarmSlider.value, newSliderValue, SmoothStop.SmoothStop2(elapsedTime / increaseTime));
			yield return null;
			elapsedTime += Time.deltaTime;
		}
		alarmSlider.value = newSliderValue;
	}

	void setAnimationNormalColour(Color newColour)
	{
		blinkAnimation.SetNormalColour(newColour);
		spikeAnimation.SetNormalColour(newColour);
		bellColourAnimation.SetAnimationColour(newColour);
	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		blinkAnimation.ResetImageColour(tracker.GetNormalColour());
		bellColourAnimation.ResetImageColour(tracker.GetNormalColour());
		alarmSlider.value = 0;
	}
}
