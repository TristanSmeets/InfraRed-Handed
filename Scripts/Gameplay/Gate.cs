using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CollectableItems;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		CollectablePickedupEvent.AddListener(onCollectablePickedup);   
    }

	void onCollectablePickedup(CollectablePickedupEvent collectablePickedup)
	{
		if (collectablePickedup.Collectable is SprayItem)
		{
			Destroy(gameObject);
		}
	}
}
