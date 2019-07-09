using UnityEngine;

namespace Alarm
{
	public class IRAlarm : AbstractAlarm
	{
		bool isTriggered = false;
		AlarmResetSound resetSound;

		protected override void Start()
		{
			base.Start();
			resetSound = GetComponent<AlarmResetSound>();
			ResolutionScreenSetup.OnLoadCheckpoint += onLoadCheckpoint;
		}

		public bool GetIsTriggered()
		{
			return isTriggered;
		}

		public void SetIsTriggered(bool value)
		{
			isTriggered = value;
			if (!value)
				resetSound.PlayResetSound();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.tag == GeneralVariables.PlayerTag && checkingCollisions && !isTriggered)
			{
				SetIsTriggered(true);
				EventQueue.EventManager.Queue(new AlarmTriggered(this));
				increaser.Increase();
			}
		}

		void onLoadCheckpoint(Checkpoint checkpoint)
		{
			isTriggered = false;
		}

		private void OnDestroy()
		{
			ResolutionScreenSetup.OnLoadCheckpoint -= onLoadCheckpoint;
		}
	}
}
