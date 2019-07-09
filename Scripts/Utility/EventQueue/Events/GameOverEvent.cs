using EventQueue;

public class GameOverEvent : GameEvent<GameOverEvent>
{
	public readonly bool IsCompleted;

	public GameOverEvent(bool isCompleted = false)
	{
		IsCompleted = isCompleted;
	}

	public override void NotifyListeners()
	{
		listeners?.Invoke(this);
	}
}
