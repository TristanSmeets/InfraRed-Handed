using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Leaderboard
{
	[SerializeField] List<LeaderboardEntry> entryList = new List<LeaderboardEntry>();

	public Leaderboard() { }

	public void AddEntry(LeaderboardEntry entry)
	{
		entryList.Add(entry);
	}

	public void RemoveEntry(LeaderboardEntry entry)
	{
		entryList.Remove(entry);
	}

	public void SortLeaderboard()
	{
		entryList.Sort();
		entryList.Reverse();
		while (entryList.Count > GeneralVariables.LeaderboardEntries)
		{
			entryList.Remove(entryList[entryList.Count - 1]);
		}
	}

	public override string ToString()
	{
		string PrintedLeaderboard = "";

		for (int index = 0; index < entryList.Count; index++)
		{
			PrintedLeaderboard += string.Format("{0}. Name: {1}\tAge: {2}\tScore: {3}\n",
				index + 1, entryList[index].Name, entryList[index].Age, entryList[index].Score);
		}
		return PrintedLeaderboard;
	}

	public string GetLeaderboardNames()
	{
		string Names = "";
		for (int index = 0; index < entryList.Count; index++)
		{
			Names += string.Format("{0}\n", entryList[index].Name, entryList[index].Age);
		}
		return Names;
	}

	public string GetLeaderboardScores()
	{
		string Scores = "";
		for (int index = 0; index < entryList.Count; index++)
		{
			Scores += string.Format("{0}\n", entryList[index].Score);
		}
		return Scores;
	}

	public string GetLeaderboardAges()
	{
		string Ages = "";
		for (int index = 0; index < entryList.Count; index++)
		{
			Ages += string.Format("{0}\n", entryList[index].Age);
		}
		return Ages;
	}

	public LeaderboardEntry GetEntry(int index)
	{
		return entryList[index];
	}

	public int GetAmountOfEntries()
	{
		return entryList.Count;
	}
}
