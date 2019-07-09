using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComicImageManager : MonoBehaviour
{
	FlyInAnimation[] flyinAnimations;
	public Transform[] StartPositions;
	float counter = 0;
	[SerializeField] float countdown = 1;
	int currentAnimation = 0;
	bool isPlaying = false;

	private void Awake()
	{
		flyinAnimations = GetComponentsInChildren<FlyInAnimation>();
		for (int index = 0; index < StartPositions.Length; index++)
		{
			flyinAnimations[index].StartPosition =  StartPositions[index].position;
			flyinAnimations[index].gameObject.SetActive(false);
		}
	}

	private void Update()
	{
		if (currentAnimation < flyinAnimations.Length && isPlaying)
		{
			counter += Time.deltaTime;
			if (counter > countdown)
			{
				flyinAnimations[currentAnimation].gameObject.SetActive(true);
				flyinAnimations[currentAnimation].PlayAnimation();
				currentAnimation++;
				counter = 0;
			}
		}
	}

	public void PlayAnimations()
	{
		isPlaying = true;
	}
}
