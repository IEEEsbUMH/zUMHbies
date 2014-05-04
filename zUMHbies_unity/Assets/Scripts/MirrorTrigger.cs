using UnityEngine;
using System.Collections;

public class MirrorTrigger : MonoBehaviour, ISwitchedByExtTrigger
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

		public void _TriggerEnterSwitch (int a_index, Collider a_collider)
		{
				if (a_collider.gameObject == player && a_index == 0)
						MyCamera.enabled = true;
		}

		public void _TriggerStaySwitch (int a_index, Collider a_collider)
		{
				//Nothin'
		}

		public void _TriggerExitSwitch (int a_index, Collider a_collider)
		{
				if (a_collider.gameObject == player && a_index == 0)
						MyCamera.enabled = false;
		}
}
