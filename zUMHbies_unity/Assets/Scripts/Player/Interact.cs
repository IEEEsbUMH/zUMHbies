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
		private GameObject lastExaminedGameobject; //reference to the last Gameobject hit and examined for an IInteractive 
		private IInteractive activeInteractiveObject;

		void Start ()
		{
				myItemManagement = GetComponent<ItemManagement> ();
				myInventoryLayout = GameObject.FindWithTag (Tags.GAME_CONTROLLER).GetComponent<InventoryLayout> ();
		}

		void Update ()
		{
				if (Input.GetButtonDown ("Interact"))
						activate ();
		
				if (Input.GetButtonDown ("PickUp") && myInventoryLayout.DisplayingInventory == false)
						pickUp ();
		
				if (Input.GetButtonDown ("PickUp") && myInventoryLayout.DisplayingInventory == true)
						drop ();
		}

		void FixedUpdate ()
		{
				if (!Interacts)
						return;

				myRay = new Ray (POV.position, POV.forward);
				if (Physics.Raycast (myRay, out rayHit, RayDistance)) {
						//print (rayHit.collider.gameObject != lastExaminedGameobject);
						if (lastExaminedGameobject == null || (lastExaminedGameobject != null && rayHit.collider.gameObject != lastExaminedGameobject)) { //Old IInteractive is no longer active, thus we run the recognition code again

								cleanReferences (); //First we clear the refernces

								lastExaminedGameobject = rayHit.collider.gameObject;
								GameObject t_candidateGO = lastExaminedGameobject; //Start candidates by the gameobject owning the collider

								bool t_stopRunning = false;
								do {
										MonoBehaviour[] t_scriptComponents = t_candidateGO.GetComponents<MonoBehaviour> ();


										if (t_scriptComponents.Length == 0) {
												//No scripts attached to the GO, jump up in hierarchy or exit the loop
												if (t_candidateGO.transform.parent != null)
														t_candidateGO = t_candidateGO.transform.parent.gameObject;
												else
														t_stopRunning = true;
						
						
										}
					
										foreach (MonoBehaviour b_behaviour in t_scriptComponents) {
												activeInteractiveObject = b_behaviour as IInteractive;
												if (activeInteractiveObject != null) {
														//activeGameObject = b_behaviour.gameObject;
														//print (activeGameObject);
														t_stopRunning = true; //Found object. Will stop loop.
														activeInteractiveObject._SetAsActiveIInteractive (true); //We inform the gameobject it's been spotted
														break; //We prevent to overwrite the reference activeInteractiveObject once we've found a proper gameObject containing an IInteractive
												} else {
														//Nothing found. Set new candidate as its parent to run the recognition code again as long as there is a parent
														if (t_candidateGO.transform.parent != null)
																t_candidateGO = t_candidateGO.transform.parent.gameObject;
														else
																t_stopRunning = true;
												}
										}
								} while(!t_stopRunning) ;//Run until told the opposite
			
						} 
				} else {
						cleanReferences ();
				}
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
								//Fail to store
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

		void cleanReferences ()
		{
				lastExaminedGameobject = null;

				//We check if both the reference and the object are not null
				if (activeInteractiveObject != null && ((Object)activeInteractiveObject).Ext_Exists ()) {
						activeInteractiveObject._SetAsActiveIInteractive (false); //Cancel the spotted state
				}
				activeInteractiveObject = null; //Set the reference to null
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
