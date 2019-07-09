using UnityEngine.AI;

namespace AI
{
	public abstract class BaseState
	{
		protected Guard owner;
		protected NavMeshAgent agent;
		public BaseState(Guard guard)
		{
			owner = guard;
			agent = owner.GetComponent<NavMeshAgent>();
		}

		//Abstract functions each state should implement
		//Enter and exit will be called on state change.
		//Update will be called every frame.
		public abstract void Enter();
		public abstract void Update();
		public abstract void Exit();
	}
}
