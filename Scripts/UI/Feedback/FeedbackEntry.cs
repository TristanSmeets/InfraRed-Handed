using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct FeedbackEntry
{
	[SerializeField] string name;
	[SerializeField] string timeStamp;
	[SerializeField] int awareness;
	[SerializeField] int opinion;
	
	public FeedbackEntry(int technologyAwareness, int technologyOpinion, string firstName, string date)
	{
		awareness = technologyAwareness;
		opinion = technologyOpinion;
		name = firstName;
		timeStamp = date;
	}

	public int GetAwareness()
	{
		return awareness;
	}

	public int GetOpinion()
	{
		return opinion;
	}
}
