using EventQueue;
using UnityEngine;

namespace Alarm
{
	public class GuardTrigger : MonoBehaviour
	{
		[SerializeField] float guardCallTime = 1.0f;
		SecurityCamera securityCamera;
		float counter = 0;
		bool eventSend = false;
		// Start is called before the first frame update
		void Start()
		{
			securityCamera = GetComponent<SecurityCamera>();
		}

		public void GuardCountdown()
		{
			counter += Time.deltaTime;
			if (counter > guardCallTime && !eventSend)
			{
				EventManager.Queue(new CameraTriggered(securityCamera));
				eventSend = true;
			}
		}

		public void ResetGuardTrigger()
		{
			counter = 0;
			eventSend = false;
		}
	}
}
