using System;
using UnityEngine;
using UnityEngine.UI;
using Language;

public class ResolutionScreenSetup : MonoBehaviour
{
	Leaderboard leaderboard;
	LeaderboardSetup leaderboardSetup;
	LeaderboardSerializer leaderboardSerializer;
	ScoreTracker scoreTracker;
	CheckpointManager checkpointManager;
	BGImageSetup imageSetup;

	public GameObject LoadCheckpointButton;

	public static event Action<Checkpoint> OnLoadCheckpoint = delegate { };

	private void Awake()
	{
		leaderboardSetup = GetComponent<LeaderboardSetup>();
		leaderboardSerializer = GetComponent<LeaderboardSerializer>();
		scoreTracker = FindObjectOfType<ScoreTracker>();
		checkpointManager = FindObjectOfType<CheckpointManager>();
		imageSetup = GetComponentInChildren<BGImageSetup>();
	}

	private void Start()
	{
		leaderboard = leaderboardSerializer.GetLeaderboard();	
	}

	void SetResolutionText(bool isCompleted)
	{
		LanguageObject language = LanguageLocator.GetLanguage();
		Text resolutionText = GetComponentInChildren<Text>();
		if (isCompleted)
		{
			resolutionText.text = language.GetResolutionText(ResolutionText.COMPLETION.SUCCESS);
		}
		else
		{
			resolutionText.text = language.GetResolutionText(ResolutionText.COMPLETION.FAILURE);
		}
	}

	public void SetupResolutionScreen(bool isCompleted)
	{
		if (LoadCheckpointButton != null)
			LoadCheckpointButton.SetActive(!isCompleted);
		SetResolutionText(isCompleted);
		imageSetup.SetBGImage(isCompleted);
	}

	public void SetupLeaderboard()
	{
		//Reset player location to starting checkpoint.
		ResetStartLocation();
		leaderboard.AddEntry(new LeaderboardEntry(
				PlayerPrefs.GetString(GeneralVariables.PlayerName),
				PlayerPrefs.GetInt(GeneralVariables.PlayerAge),
				(int)scoreTracker.GetCurrentScore()));
		leaderboard.SortLeaderboard();
		leaderboardSerializer.SerializeLeaderboard(leaderboard);

		leaderboardSetup.SetPlayerName();
		leaderboardSetup.SetLeaderboardNames(leaderboard.GetLeaderboardNames());
		leaderboardSetup.SetLeaderboardScores(leaderboard.GetLeaderboardScores());
		leaderboardSetup.SetLeaderboardAges(leaderboard.GetLeaderboardAges());
	}

	public void ResetStartLocation()
	{
		checkpointManager.ResetStartLocation();
	}

	public void LoadCheckpoint()
	{
		OnLoadCheckpoint?.Invoke(checkpointManager.GetActiveCheckpoint());
	}
}
