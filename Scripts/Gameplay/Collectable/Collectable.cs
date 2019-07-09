using UnityEngine;

namespace CollectableItems
{
	public class Collectable : MonoBehaviour
	{
		Vector3 collectablePosition;
		protected GameObject collectButton;
		PickupButton pickupButton;
		[SerializeField] protected uint itemScore = 10;

		protected virtual void Awake()
		{
			pickupButton = GameObject.FindObjectOfType<PickupButton>();
			collectButton = pickupButton.gameObject;
			Collider collider = GetComponent<Collider>();
			collider.enabled = enabled;
			collider.isTrigger = true;
		}

		// Start is called before the first frame update
		protected virtual void Start()
		{
			ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
			collectablePosition = transform.position;
			collectButton.SetActive(false);
		}

		protected virtual void OnTriggerEnter(Collider other)
		{
			pickupButton.SetCollectable(this);
			collectButton.SetActive(true);
		}

		protected virtual void OnTriggerExit(Collider other)
		{
			collectButton.SetActive(false);
		}

		public virtual uint GetItemValue()
		{
			return itemScore;
		}

		protected virtual void onLoadCheckpoint(Checkpoint checkpoint)
		{
			transform.position = collectablePosition;
		}

		protected virtual void OnDestroy()
		{
			ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
		}

		public Vector3 GetCollectablePosition()
		{
			return collectablePosition;
		}
	}
}
