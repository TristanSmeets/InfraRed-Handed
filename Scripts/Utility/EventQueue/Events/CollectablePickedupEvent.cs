using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EventQueue;
using CollectableItems;

public class CollectablePickedupEvent : GameEvent<CollectablePickedupEvent>
{
	public readonly Collectable Collectable;
	public CollectablePickedupEvent(Collectable collectable)
	{
		Collectable = collectable;
	}

	public override void NotifyListeners()
	{
		listeners?.Invoke(this);
	}
}
