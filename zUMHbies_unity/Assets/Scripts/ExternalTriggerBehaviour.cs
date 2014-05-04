using UnityEngine;
using System.Collections;

public class ExternalTriggerBehaviour : MonoBehaviour
{
		public MonoBehaviour[] Target; //Target must implement ISwitchableByExtTrigger before activation
		public int Index;

		public bool SendEnterMessage;
		public bool SendStayMessage;
		public bool SendExitMessage;

		private ISwitchedByExtTrigger[] toTrigger;

		void Start ()
		{
				toTrigger = new ISwitchedByExtTrigger[Target.Length];
				for (int i=0; i<Target.Length; i++) {
						toTrigger [i] = Target [i] as ISwitchedByExtTrigger;
						if (toTrigger [i] == null) {
								Debug.LogWarning ("Warning: " + gameObject.name + "'s ExternalTriggerBehaviour contains a reference to a non ISwitchedByExtTrigger MonoBehaviour");
								this.enabled = false;
						}
				}

				
		}

		void OnTriggerEnter (Collider a_collider)
		{
				if (SendEnterMessage) {
						foreach (ISwitchedByExtTrigger a_toTrigger in toTrigger) {
								a_toTrigger._TriggerEnterSwitch (Index, a_collider);
						}
				}
						
		}

		void OnTriggerStay (Collider a_collider)
		{
				if (SendStayMessage) {
						//print (gameObject.name);
						foreach (ISwitchedByExtTrigger a_toTrigger in toTrigger) {
								a_toTrigger._TriggerStaySwitch (Index, a_collider);
						}
				}
		}

		void OnTriggerExit (Collider a_collider)
		{
				if (SendExitMessage) {
						foreach (ISwitchedByExtTrigger a_toTrigger in toTrigger) {
								a_toTrigger._TriggerExitSwitch (Index, a_collider);
						}
				}
		}
}
