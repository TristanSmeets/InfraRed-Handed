using UnityEngine;

public class EndZone : MonoBehaviour
{
	bool isLevelCompleted = false;

	// Start is called before the first frame update
	void Start()
	{
		CollectablePickedupEvent.AddListener(onCollectablePickup);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == GeneralVariables.PlayerTag && isLevelCompleted)
		{
			EventQueue.EventManager.Queue(new GameOverEvent(true));
		}
	}

	void onCollectablePickup(CollectablePickedupEvent collectablePickedupEvent)
	{
		if (collectablePickedupEvent.Collectable is FinalItem)
			isLevelCompleted = true;
	}

	private void OnDestroy()
	{
		CollectablePickedupEvent.RemoveListener(onCollectablePickup);
	}
}
