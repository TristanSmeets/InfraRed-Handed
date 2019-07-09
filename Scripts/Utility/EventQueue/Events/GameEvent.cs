namespace EventQueue
{
	public abstract class BaseEvent
	{
		public abstract void NotifyListeners();
	}

	public abstract class GameEvent<T> : BaseEvent where T : BaseEvent
	{
		public delegate void Listener<U>(T t);
		protected static Listener<T> listeners;

		public static void AddListener(Listener<T> subscriber)
		{
			if (subscriber != null) listeners += subscriber;
		}

		public static void RemoveListener(Listener<T> subscriber)
		{
			if (subscriber != null) listeners -= subscriber;
		}

		public static void ClearListeners()
		{
			listeners = null;
		}
	}
}
