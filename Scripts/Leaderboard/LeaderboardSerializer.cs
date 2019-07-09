using System;
using System.IO;
using UnityEngine;

public class LeaderboardSerializer : MonoBehaviour
{
	Leaderboard leaderboard;
	public string DirectoryPath;
	DateTime dateTime;
	string date;

	private void Awake()
	{
		dateTime = DateTime.Today;
		date = string.Format("{0}-{1}-{2}", dateTime.Day, dateTime.Month, dateTime.Year);
		try
		{
			
			leaderboard = DeserializeLeaderboard(DirectoryPath + "\\" + date + ".json");
		}
		catch
		{
			leaderboard = CreateNewLeaderboard();
		}
	}

	public void SerializeLeaderboard(Leaderboard leaderboard)
	{
		Directory.CreateDirectory(DirectoryPath);
		using (StreamWriter writer = new StreamWriter(DirectoryPath + "\\" + date + ".json"))
		{
			string json = JsonUtility.ToJson(leaderboard);
			writer.Write(json);
		}
	}

	public Leaderboard DeserializeLeaderboard(string filePath)
	{
		using (StreamReader stream = new StreamReader(filePath))
		{
			string json = stream.ReadToEnd();
			return JsonUtility.FromJson<Leaderboard>(json);
		}
	}

	public Leaderboard GetLeaderboard()
	{
		return leaderboard;
	}

	public Leaderboard CreateNewLeaderboard()
	{
		Leaderboard newLeaderboard = new Leaderboard();
		newLeaderboard.AddEntry(new LeaderboardEntry("Erika", 10, 10));
		newLeaderboard.AddEntry(new LeaderboardEntry("Inken", 11, 10));
		newLeaderboard.AddEntry(new LeaderboardEntry("Selima", 5, 10));
		newLeaderboard.AddEntry(new LeaderboardEntry("Stimona", 7, 10));
		newLeaderboard.AddEntry(new LeaderboardEntry("Tristan", 8, 10));
		return newLeaderboard;
	}
}
