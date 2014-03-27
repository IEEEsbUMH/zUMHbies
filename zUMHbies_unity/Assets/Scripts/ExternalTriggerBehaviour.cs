using UnityEngine;
using System.Collections;

public class ExternalTriggerBehaviour : MonoBehaviour
{
		public MonoBehaviour Target; //Target must implement ISwitchableByExtTrigger before activation
		public int Index;

		public bool SendEnterMessage;
		public bool SendStayMessage;
		public bool SendExitMessage;

		private ISwitchedByExtTrigger toTrigger;

		void Start ()
		{
				toTrigger = Target as ISwitchedByExtTrigger;
				if (toTrigger == null) {
						print ("Warning: " + gameObject.name + "'s ExternalTriggerBehaviour does not contain a reference to a ISwitchedByExtTrigger");
						this.enabled = false;
				}
		}

		void OnTriggerEnter (Collider a_collider)
		{
				if (SendEnterMessage)
						toTrigger._TriggerEnterSwitch (Index, a_collider);
		}

		void OnTriggerStay (Collider a_collider)
		{
				if (SendStayMessage)
						toTrigger._TriggerStaySwitch (Index, a_collider);
		}

		void OnTriggerExit (Collider a_collider)
		{
				if (SendExitMessage)
						toTrigger._TriggerExitSwitch (Index, a_collider);
		}
}
