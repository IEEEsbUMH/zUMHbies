using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour
{
		public bool Interacts; //Used for disabling interaction in certain ocasions
		public Transform POV;
		public float RayDistance;
		public float DropDistance;

		private ItemManagement myItemManagement;
		private InventoryLayout myInventoryLayout;

		private Ray myRay;
		private RaycastHit rayHit;
		private GameObject activeGameObject; //reference to the Gameobject containing the IInteractive, used for performance reasons
		private IInteractive activeInteractiveObject;

		void Start ()
		{
				myItemManagement = GetComponent<ItemManagement> ();
				myInventoryLayout = GameObject.FindWithTag (Tags.GAME_CONTROLLER).GetComponent<InventoryLayout> ();
		}

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
						activate ();

				if (Input.GetButtonDown ("PickUp") && myInventoryLayout.DisplayingInventory == false)
						pickUp ();

				if (Input.GetButtonDown ("PickUp") && myInventoryLayout.DisplayingInventory == true)
						drop ();
		}

		void activate ()
		{
				if (activeInteractiveObject != null) {
						activeInteractiveObject._Activate ();
				}
		}

		void pickUp ()
		{
				IPickable t_pickable = activeInteractiveObject as IPickable;
				if (t_pickable != null) {
						if (myItemManagement.StorePickable (t_pickable)) {
								//Success
						} else {
								//Fail
						}
				}
		}

		void drop ()
		{
				IPickable t_pickable = myInventoryLayout.RetrieveSelectedPickable ();
				if (t_pickable != null) {		
						t_pickable._Place (null, getDropPoint ());
				}
		}

		Vector3 getDropPoint ()
		{
				myRay = new Ray (POV.position, POV.forward);
				if (Physics.Raycast (myRay, out rayHit, DropDistance)) {
						return rayHit.point;
				} else {
						return POV.position + POV.forward * DropDistance;
				}
		}
}
