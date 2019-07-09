using EventQueue;
using Alarm;

public class AlarmTriggered : GameEvent<AlarmTriggered>
{
	public readonly IRAlarm Alarm;

	public AlarmTriggered(IRAlarm alarm)
	{
		Alarm = alarm;
	}

	public override void NotifyListeners()
	{
		listeners?.Invoke(this);
	}
}
