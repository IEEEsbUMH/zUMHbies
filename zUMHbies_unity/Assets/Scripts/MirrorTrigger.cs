using UnityEngine;
using System.Collections;

public class MirrorTrigger : MonoBehaviour
{
		public Camera MyCamera;

		protected GameObject player;
		//protected bool isWorking;

		void Start ()
		{
				player = GameObject.FindGameObjectWithTag (Tags.GAME_CONTROLLER).GetComponent<PlayerReferences> ().Player;

				//Disable the camera at first
				MyCamera.enabled = false;
		}

		void OnBecameVisible ()
		{
				MyCamera.enabled = true;
		}

		void OnBecameInvisible ()
		{
				MyCamera.enabled = false;
		}

		/*void Update ()
		{
				if (MyCamera.enabled) {
						Vector3 relativePos = transform.worldToLocalMatrix * player.transform.position;
						MyCamera.transform.position = new Vector3 (player.transform.position.x, MyCamera.transform.position.y);
				}
		}*/
}
