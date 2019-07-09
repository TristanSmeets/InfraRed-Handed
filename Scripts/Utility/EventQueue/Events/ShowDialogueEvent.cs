using EventQueue;

public class ShowDialogueEvent : GameEvent<ShowDialogueEvent>
{
	public readonly string Message;

	public ShowDialogueEvent(string message)
	{
		Message = message;
	}

	public override void NotifyListeners()
	{
		listeners?.Invoke(this);
	}
}
