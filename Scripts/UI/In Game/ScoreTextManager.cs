using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextManager : MonoBehaviour
{
	List<TextMovementAnimation> textMovements = new List<TextMovementAnimation>();
	Transform uiCanvas;
	public GameObject FlyingScoreText;
	public Vector3 Offset;
	ScoreIndicator scoreIndicator;
	Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
		mainCamera = Camera.main;
		uiCanvas = FindObjectOfType<Canvas>().gameObject.transform;
		scoreIndicator = FindObjectOfType<ScoreIndicator>();
		CollectablePickedupEvent.AddListener(onCollectablePickedup);
    }

	public TextMovementAnimation GetUnusedText()
	{
		for (int index = 0; index < textMovements.Count; ++index)
		{
			if (!textMovements[index].GetInUse())
				return textMovements[index];
		}
		return createNewTextAnimation();
	}

	TextMovementAnimation createNewTextAnimation()
	{
		GameObject newScoreText = Instantiate(FlyingScoreText, uiCanvas);
		TextMovementAnimation newText = newScoreText.GetComponent<TextMovementAnimation>();
		textMovements.Add(newText);
		return newText;
	}

	void onCollectablePickedup(CollectablePickedupEvent collectablePickedup)
	{
		CollectableItems.Collectable collectable = collectablePickedup.Collectable;

		if (collectable.GetItemValue() > 0)
		{
			TextMovementAnimation textMovement = GetUnusedText();
			textMovement.StartPosition = mainCamera.WorldToScreenPoint(collectable.GetCollectablePosition() + Vector3.up);
			textMovement.EndPosition = scoreIndicator.transform.position + Offset;
			textMovement.SetScoreText(string.Format("+ {0}", collectable.GetItemValue()));
			textMovement.PlayAnimation();
		}
	}

	private void OnDestroy()
	{
		CollectablePickedupEvent.RemoveListener(onCollectablePickedup);
	}
}
