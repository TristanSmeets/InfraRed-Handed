using UnityEngine;
using UnityEngine.UI;

public class LeaderboardSetup : MonoBehaviour
{
	public Text LeaderboardNames;
	public Text LeaderboardScores;
	public Text LeaderboardAges;
	public Text PlayerName;
	public Text PlayerScore;

	public void SetPlayerName()
	{
		ScoreTracker scoreTracker = FindObjectOfType<ScoreTracker>();
		if (PlayerName != null)
			PlayerName.text = string.Format("{0}", PlayerPrefs.GetString(GeneralVariables.PlayerName));
		if (PlayerScore != null)
			PlayerScore.text = string.Format("score: {0}", (int)scoreTracker.GetCurrentScore());
	}

	public void SetLeaderboardNames(string text)
	{
		LeaderboardNames.text = text;
	}

	public void SetLeaderboardScores(string text)
	{
		LeaderboardScores.text = text;
	}

	public void SetLeaderboardAges(string text)
	{
		LeaderboardAges.text = text;
	}

	public void SetupLeaderboard(LeaderboardSerializer leaderboardSerializer)
	{
		Leaderboard leaderboard = leaderboardSerializer.GetLeaderboard();

		SetLeaderboardAges(leaderboard.GetLeaderboardAges());
		SetLeaderboardNames(leaderboard.GetLeaderboardNames());
		SetLeaderboardScores(leaderboard.GetLeaderboardScores());
	}
}
