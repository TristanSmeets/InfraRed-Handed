using UnityEngine;

namespace Movement
{
	[RequireComponent(typeof(Controllable), typeof(UserInput))]
	public class Player : MonoBehaviour
	{
		Controllable controllable;
		UserInput inputProvider;

		// Start is called before the first frame update
		void Start()
		{
			gameObject.layer = LayerMask.NameToLayer(GeneralVariables.PlayerTag);
			controllable = GetComponent<Controllable>();
			inputProvider = GetComponent<UserInput>();

			//hooking up components
			inputProvider.OnTapStart += controllable.TapStartPosition;
			inputProvider.OnTapMove += controllable.TapMove;
			inputProvider.OnTapEnd += controllable.TapEnd;

			GameOverEvent.AddListener(onGameOver);
			ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
		}

		private void OnDestroy()
		{
			//Decoupling components
			inputProvider.OnTapStart -= controllable.TapStartPosition;
			inputProvider.OnTapMove -= controllable.TapMove;
			inputProvider.OnTapEnd -= controllable.TapEnd;

			GameOverEvent.RemoveListener(onGameOver);
			ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
		}

		void onGameOver(GameOverEvent gameOver)
		{
			inputProvider.OnTapStart -= controllable.TapStartPosition;
			inputProvider.OnTapMove -= controllable.TapMove;
			inputProvider.OnTapEnd -= controllable.TapEnd;
		}

		void onLoadCheckpoint(Checkpoint checkpoint)
		{
			inputProvider.OnTapStart += controllable.TapStartPosition;
			inputProvider.OnTapMove += controllable.TapMove;
			inputProvider.OnTapEnd += controllable.TapEnd;
		}
	}
}
