using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spray;

namespace CollectableItems
{
	public class SprayItem : Collectable
	{
		GameObject SprayButton;
		SprayActivation sprayActivation;
		// Start is called before the first frame update
		protected override void Awake()
		{
			base.Awake();
			sprayActivation = FindObjectOfType<SprayActivation>();
			SprayButton = GameObject.FindObjectOfType<SprayActivation>().gameObject;
		}
		protected override void Start()
		{
			base.Start();
			SprayButton.SetActive(false);
			sprayActivation.SetSprayButton(false);
		}

		public void ActivateSprayButton()
		{
			sprayActivation.SetSprayButton(true);
		}

		protected override void onLoadCheckpoint(Checkpoint checkpoint)
		{
		}
	}
}
