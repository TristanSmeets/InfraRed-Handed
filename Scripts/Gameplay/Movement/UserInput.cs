using UnityEngine;

namespace Movement
{
	public class UserInput : InputProvider
	{
		Vector2 startPosition;
		// Update is called once per frame
		void Update()
		{
			mouseInput();
		}

		void mouseInput()
		{
			if (Input.GetMouseButtonDown(0))
			{
				startPosition = Input.mousePosition;
				ExecuteOnTapStart(startPosition);
			}
			if (Input.GetMouseButton(0) &&
				startPosition.x + Mathf.Epsilon != Input.mousePosition.x + Mathf.Epsilon &&
				startPosition.y + Mathf.Epsilon != Input.mousePosition.y + Mathf.Epsilon)
			{
				Vector2 newDirection = (Vector2)Input.mousePosition - startPosition;
				ExecuteOnTapMove(newDirection);
			}
			if (Input.GetMouseButtonUp(0))
				ExecuteOnTapEnd();
		}
	}
}
