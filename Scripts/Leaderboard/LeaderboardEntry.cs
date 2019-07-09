using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LeaderboardEntry : IComparable
{
	public string Name;
	public int Age;
	public int Score;

	public LeaderboardEntry(string name, int age, int score)
	{
		Name = name;
		Age = age;
		Score = score;
	}

	public int CompareTo(object obj)
	{
		if (obj == null) return 1;
		LeaderboardEntry other = obj as LeaderboardEntry;

		if (other != null)
			return this.Score.CompareTo(other.Score);
		else
			throw new ArgumentException("Object is not a LeaderboardEntry");
	}
}
