using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Alarm;
using System;

namespace AI
{
	public class SecurityCameraManager : MonoBehaviour
	{
		public SecurityCamera[] SecurityCameras;
		public event Action<SecurityCamera> SecurityCameraTriggered = delegate { };

		// Start is called before the first frame update
		void Start()
		{
			//Listen to CameraTriggered events.
			CameraTriggered.AddListener(onCameraTriggered);
		}

		void onCameraTriggered(CameraTriggered cameraTriggered)
		{
			for (int index = 0; index < SecurityCameras.Length; ++index)
			{
				if (cameraTriggered.SecurityCamera == SecurityCameras[index])
					SecurityCameraTriggered(cameraTriggered.SecurityCamera);
			}
		}
		private void OnDestroy()
		{
			CameraTriggered.RemoveListener(onCameraTriggered);
		}
	}
}
