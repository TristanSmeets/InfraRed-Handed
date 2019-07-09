using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
	Controllable playerControllable;
	Animator animator;

    // Start is called before the first frame update
    void Start()
    {
		playerControllable = GameObject.FindGameObjectWithTag(GeneralVariables.PlayerTag).GetComponent<Controllable>();
		animator = GetComponentInChildren<Animator>();
		GameOverEvent.AddListener(onGameOver);
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
    }

    // Update is called once per frame
    void Update()
    {
		animator.SetFloat("Speed", playerControllable.GetMoveSpeed());
    }

	void onGameOver(GameOverEvent gameOver)
	{
		if (gameOver.IsCompleted)
			animator.SetTrigger("Win");
		else
			animator.SetTrigger("Lose");
	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		animator.SetTrigger("Reset");
	}

	private void OnDestroy()
	{
		GameOverEvent.RemoveListener(onGameOver);
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}
}
