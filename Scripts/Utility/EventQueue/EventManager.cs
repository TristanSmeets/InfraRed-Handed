using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventQueue
{
	public class EventManager : MonoBehaviour
	{
		private static List<BaseEvent> events;

		private void Awake()
		{
			events = new List<BaseEvent>();
		}

		public static void Queue(BaseEvent gameEvent)
		{
			if (gameEvent != null) events.Add(gameEvent);
		}

		public static void Dispatch()
		{
			for (int index = 0; index < events.Count; index++)
			{
				BaseEvent baseEvent = events[index];
				if (baseEvent != null)
					baseEvent.NotifyListeners();
			}
			events.Clear();
		}

		// Update is called once per frame
		void LateUpdate()
		{
			Dispatch();
		}

		private void OnDestroy()
		{
			AlarmTriggered.ClearListeners();
			CameraTriggered.ClearListeners();
			CollectablePickedupEvent.ClearListeners();
			GameOverEvent.ClearListeners();
			AlarmStateChanged.ClearListeners();
			ShowDialogueEvent.ClearListeners();
		}
	}
}
