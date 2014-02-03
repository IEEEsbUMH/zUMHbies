using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour
{
		public bool Interacts; //Used for disabling interaction in certain ocasions
		public Transform POV;
		public float RayDistance;

		private Ray myRay;
		private RaycastHit rayHit;
		private IInteractive activeInteractiveObject;


		void FixedUpdate ()
		{
				if (!Interacts)
						return;

				myRay = new Ray (POV.position, POV.forward);
				if (Physics.Raycast (myRay, out rayHit, RayDistance)) {
						MonoBehaviour[] ScriptComponents = rayHit.collider.gameObject.GetComponents<MonoBehaviour> ();
		
						foreach (MonoBehaviour b_behaviour in ScriptComponents) {
								activeInteractiveObject = b_behaviour as IInteractive;
								if (activeInteractiveObject != null)
										break;
								
						}

				} else {
						activeInteractiveObject = null;
				}

				if (Input.GetAxis ("Interact") > 0)
						Activate ();
				

				if (Input.GetAxis ("PickUp") > 0)
						PickUp ();
		}

		void Activate ()
		{
				if (activeInteractiveObject != null)
						activeInteractiveObject.Activate ();
		}

		void PickUp ()
		{
				IPickable t_pickable = activeInteractiveObject as IPickable;
				if (t_pickable != null) {
					
				}
		}
}
