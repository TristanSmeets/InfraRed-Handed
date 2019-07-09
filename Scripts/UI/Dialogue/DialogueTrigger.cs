using Spray;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
	Text dialogueText;
	Vector3 StartPosition;
	FlyInAnimation flyInAnimation;
	FlyOutAnimation flyOutAnimation;
	GameObject sprayObject;
	Button dialogueBoxButton;

	// Start is called before the first frame update
	void Awake()
	{
		StartPosition = new Vector3(Screen.width * 0.5f, -Screen.height * 0.25f, 0);
		sprayObject = GameObject.FindObjectOfType<SprayActivation>().gameObject;
		flyInAnimation = GetComponent<FlyInAnimation>();
		flyOutAnimation = GetComponent<FlyOutAnimation>();
		dialogueText = GetComponentInChildren<Text>();
		dialogueBoxButton = GetComponent<Button>();
	}

	void Start()
	{
		flyInAnimation.StartPosition = StartPosition;
		flyOutAnimation.EndPosition = StartPosition;
		gameObject.transform.position = StartPosition;
		dialogueBoxButton.interactable = false;
		ShowDialogueEvent.AddListener(onShowDialogue);
		ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
	}

	void onShowDialogue(ShowDialogueEvent showDialogue)
	{
		dialogueBoxButton.interactable = true;
		sprayObject.SetActive(false);
		dialogueText.text = showDialogue.Message;
		Time.timeScale = 0;
		flyInAnimation.PlayAnimation();
	}

	public void CloseDialogueBox()
	{
		sprayObject.SetActive(true);
		Time.timeScale = 1;
		flyOutAnimation.PlayAnimation();
		dialogueBoxButton.interactable = false;
	}

	private void OnDestroy()
	{
		ShowDialogueEvent.RemoveListener(onShowDialogue);
		ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
	}

	void onLoadCheckpoint(Checkpoint checkpoint)
	{
		gameObject.transform.position = StartPosition;
	}
}
