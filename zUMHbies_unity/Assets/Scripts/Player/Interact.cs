using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour
{
		public bool Interacts; //Used for disabling interaction in certain ocasions
		public Transform POV;
		public float RayDistance;

		private Ray myRay;
		private RaycastHit rayHit;
		private GameObject activeGameObject; //reference to the Gameobject containing the IInteractive, used for performance reasons
		private IInteractive activeInteractiveObject;


		void FixedUpdate ()
		{
				if (!Interacts)
						return;

				myRay = new Ray (POV.position, POV.forward);
				if (Physics.Raycast (myRay, out rayHit, RayDistance)) {

						if (activeGameObject == null || (activeGameObject != null && rayHit.collider.gameObject != activeGameObject)) { //Old IInteractive is no longer active, thus we run the recognition code again
								MonoBehaviour[] ScriptComponents = rayHit.collider.gameObject.GetComponents<MonoBehaviour> ();
					
								foreach (MonoBehaviour b_behaviour in ScriptComponents) {
										activeInteractiveObject = b_behaviour as IInteractive;
										if (activeInteractiveObject != null) {
												activeGameObject = b_behaviour.gameObject;
												break;
										}
								}
						}
							
				} else {
						activeGameObject = null;
						activeInteractiveObject = null;
				}

				if (Input.GetButtonDown ("Interact"))
						Activate ();
				

				if (Input.GetButtonDown ("PickUp"))
						PickUp ();
		}

		void Activate ()
		{
				if (activeInteractiveObject != null) {
						activeInteractiveObject.Activate ();
				}
		}

		void PickUp ()
		{
				IPickable t_pickable = activeInteractiveObject as IPickable;
				if (t_pickable != null) {
					
				}
		}
}
