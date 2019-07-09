using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
	public void CloseGame()
	{
#if UNITY_EDITOR
		Debug.LogFormat("Closing game");
#else
		Application.Quit();
#endif
	}
}
