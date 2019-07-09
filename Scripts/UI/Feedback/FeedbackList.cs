using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class FeedbackList
{
	[SerializeField] string team = "BrockNoEyes99";
	[SerializeField] string game = "InfraRed Handed";
	[SerializeField] float averageOpinion;
	[SerializeField] float averageAwareness;
	[SerializeField] int amountOfPlayers;
	[SerializeField] List<FeedbackEntry> feedbackEntries;

	public FeedbackList()
	{
		feedbackEntries = new List<FeedbackEntry>();
	}

	public void AddEntry(FeedbackEntry entry)
	{
		feedbackEntries.Add(entry);
		amountOfPlayers = feedbackEntries.Count;
		CalculateAverageOpinion();
		CalculateAverageAwareness();
	}

	public void RemoveEntry(FeedbackEntry entry)
	{
		if (feedbackEntries.Contains(entry))
		{
			feedbackEntries.Remove(entry);
			amountOfPlayers = feedbackEntries.Count;
			CalculateAverageOpinion();
			CalculateAverageAwareness();
		}
	}

	public void CalculateAverageOpinion()
	{
		float SumOpinion = 0;
		for (int index = 0; index < feedbackEntries.Count; index++)
		{
			SumOpinion += feedbackEntries[index].GetOpinion();
		}
		averageOpinion = SumOpinion / feedbackEntries.Count;
	}

	public void CalculateAverageAwareness()
	{
		float SumAwareness = 0;

		for (int index = 0; index < feedbackEntries.Count; index++)
		{
			SumAwareness += feedbackEntries[index].GetAwareness();
		}
		averageAwareness = SumAwareness / feedbackEntries.Count;
	}
}
