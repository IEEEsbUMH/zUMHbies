using UnityEngine;
using System.Collections;

public class OVR_Control : MonoBehaviour
{
		public GameObject[] NormalCameras;
		public GameObject OVRCameraControllerInstance;

		[SerializeField]
		private bool
				Debug_UsingOVR;
	
		void Start ()
		{
				if (Debug_UsingOVR)
						OVR_Helper.UsingOVR = true;

				if (OVR_Helper.UsingOVR) {
						foreach (GameObject b_go in NormalCameras) {
								b_go.SetActive (false);
						}
						OVRCameraControllerInstance.SetActive (true);
				} else {
						foreach (GameObject b_go in NormalCameras) {
								b_go.SetActive (true);
						}
						OVRCameraControllerInstance.SetActive (false);
				}
		}
}
