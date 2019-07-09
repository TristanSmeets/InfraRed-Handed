using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Movement
{
	public class InputProvider : MonoBehaviour
	{
		public event Action<Vector2> OnTapStart = delegate { };
		public event Action<Vector2> OnTapMove = delegate { };
		public event Action OnTapEnd = delegate { };

		protected void ExecuteOnTapStart(Vector2 position) { OnTapStart(position); }
		protected void ExecuteOnTapMove(Vector2 direction) { OnTapMove(direction); }
		protected void ExecuteOnTapEnd() { OnTapEnd(); }
	}
}
