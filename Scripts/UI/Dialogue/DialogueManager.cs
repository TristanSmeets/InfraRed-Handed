using CollectableItems;
using EventQueue;
using UnityEngine;
using Language;

public class DialogueManager : MonoBehaviour
{
	//public string StartDialogue = "Start Game Dialogue";
	//public string SprayDialogue = "Spray Collected";
	//public string EndDialogue = "Game Completed";

	Language.LanguageObject language;
	// Start is called before the first frame update
	void Start()
	{
		language = LanguageLocator.GetLanguage();
		CollectablePickedupEvent.AddListener(onCollectablePickedup);
		string StartDialogue = language.GetDialogueText(DialogueText.DIALOGUE_TYPE.START);
		EventManager.Queue(new ShowDialogueEvent(StartDialogue));
	}

	void onCollectablePickedup(CollectablePickedupEvent collectablePickedup)
	{
		if (collectablePickedup.Collectable is SprayItem)
		{
			string SprayDialogue = language.GetDialogueText(DialogueText.DIALOGUE_TYPE.SPRAY);
			EventManager.Queue(new ShowDialogueEvent(SprayDialogue));
		}
		if (collectablePickedup.Collectable is FinalItem)
		{
			string EndDialogue = language.GetDialogueText(DialogueText.DIALOGUE_TYPE.YARN);
			EventManager.Queue(new ShowDialogueEvent(EndDialogue));
		}
	}
	private void OnDestroy()
	{
		CollectablePickedupEvent.RemoveListener(onCollectablePickedup);
	}
}
