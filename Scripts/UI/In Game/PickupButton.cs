using CollectableItems;
using UnityEngine;

public class PickupButton : MonoBehaviour
{
	[SerializeField] Vector3 offset = Vector3.zero;
	Collectable collectable;
	Camera mainCamera;
	// Start is called before the first frame update
	void Start()
	{
		mainCamera = Camera.main;
	}

	public void OnButtonClick()
	{
		EventQueue.EventManager.Queue(new CollectablePickedupEvent(collectable));
		if (collectable is SprayItem)
		{
			SprayItem sprayItem = collectable as SprayItem;
			sprayItem.ActivateSprayButton();
			Destroy(sprayItem.gameObject);
		}
		collectable.transform.position = Vector3.zero;
		gameObject.SetActive(false);
	}

	public void SetCollectable(Collectable collectable)
	{
		this.collectable = collectable;
	}

	private void LateUpdate()
	{
		if (collectable != null)
			transform.position = mainCamera.WorldToScreenPoint(collectable.transform.position + Vector3.up + offset);
	}
}
