using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackCreator : MonoBehaviour
{
	Slider[] feedbackSliders;
	SerializeFeedback serializeFeedback;
	private void Awake()
	{
		feedbackSliders = GetComponentsInChildren<Slider>();
		serializeFeedback = new SerializeFeedback();
	}

	public void CreateFeedbackEntry()
	{
		int opinion = (int)feedbackSliders[0].value + 1;
		int awareness = (int)feedbackSliders[1].value + 1;
		string name = PlayerPrefs.GetString(GeneralVariables.PlayerName);
		DateTime dateTime = DateTime.Now;
		string date = dateTime.ToString();
		FeedbackEntry entry = new FeedbackEntry(awareness, opinion, name, date);
		serializeFeedback.AddFeedbackEntry(entry);
		serializeFeedback.Serialize();
	}
}
