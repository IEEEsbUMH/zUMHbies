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
				OVR_Helper.UsingOVR = Debug_UsingOVR;

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
