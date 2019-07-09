public static class GeneralVariables
{
	public enum ALARMSTATE { NONE, LOW, HIGH, FULL };
	public enum SFX { ALARM_TRIGGERED, ALARM_RESET, SPRAY_EMPTY, SPRAY_FULL, COLLECTABLE, GAME_OVER };
	public enum GUARD_ICON { DOTS, QUESTION_MARK, EXCLAMATION };
	public const string PlayerTag = "Player";
	public const string ActiveAlarmTag = "Laserbeam";
	public const string ShaderTransparency = "_Transparency";
	public const uint AmountOfLocationsToCheck = 2;
	public const float FixedTimeStep = 0.01666f;
	public const string PlayerName = "PlayerName";
	public const string PlayerAge = "PlayerAge";
	public const string PlayerScore = "PlayerScore";
	public const float GuardScanningRange = 25.0f;
	public const float GuardRotationSpeed = 50.0f;
	public const int LeaderboardEntries = 10;
	public const int NameLength = 10;
}
