using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Spray
{
	public class SprayActivation : MonoBehaviour
	{
		Transform playerLocation;
		[SerializeField] float cooldownTime = 2;
		[SerializeField] float abilityDestroyTime = 0.1f;
#pragma warning disable 0649
		[SerializeField] Image[] fillImages;
#pragma warning restore 0649
		Image[] allImages;
		Button buttonComponent;

		public GameObject sprayAbility;
		bool onCooldown = false;
		public event Action OnFullSprayActivation = delegate { };
		public event Action OnEmptySprayActivation = delegate { };

		// Start is called before the first frame update
		void Awake()
		{
			allImages = GetComponentsInChildren<Image>();
			buttonComponent = GetComponent<Button>();
			playerLocation = GameObject.FindGameObjectWithTag(GeneralVariables.PlayerTag).transform;
		}

		private void Start()
		{
			OnFullSprayActivation += onFullSprayActivation;
			ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
		}
		public void ActivateExplosion()
		{
			if (!onCooldown)
			{
				OnFullSprayActivation();
			}
			else
				OnEmptySprayActivation();
		}

		private void onFullSprayActivation()
		{
			onCooldown = true;
			StartCoroutine(startCooldown(cooldownTime));
			GameObject newSprayAbility = Instantiate(sprayAbility);
			newSprayAbility.transform.position = playerLocation.position;
			Destroy(newSprayAbility, abilityDestroyTime);
		}

		void setImagesFillAmount(float value)
		{
			for (int index = 0; index < fillImages.Length; index++)
			{
				fillImages[index].fillAmount = value;
			}
		}

		IEnumerator startCooldown(float cooldownTime)
		{
			float elapsedTime = 0;
			setImagesFillAmount(0);

			while (elapsedTime <= cooldownTime)
			{
				float portionFilled = Mathf.Lerp(0, 1, EasingTristan.SmoothStartSmoothStop.SmoothStart2SmoothStop2(elapsedTime / cooldownTime));
				setImagesFillAmount(portionFilled);
				yield return null;
				elapsedTime += Time.deltaTime;
			}
			onCooldown = false;
			setImagesFillAmount(1);
		}

		public void SetSprayButton(bool value)
		{
			for (int index = 0; index < allImages.Length; index++)
			{
				allImages[index].enabled = value;
			}

			buttonComponent.enabled = value;
		}

		private void OnDestroy()
		{
			OnFullSprayActivation = null;
			OnEmptySprayActivation = null;
			ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
		}

		void onLoadCheckpoint(Checkpoint checkpoint)
		{
			StopAllCoroutines();
			onCooldown = false;
			setImagesFillAmount(1);
		}
	}
}
