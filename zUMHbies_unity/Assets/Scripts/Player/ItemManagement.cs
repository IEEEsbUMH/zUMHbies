using UnityEngine;
using System.Collections;

public class ItemManagement : MonoBehaviour
{
		public int BagSize;
		public IPickable[] bagContent;
		public IPickable[] handsContent; //0 for left, 1 for right
		public Transform LeftHand;
		public Transform RightHand;

		private IAnimationManager myAnimManager;

		// Use this for initialization
		void Start ()
		{
				bagContent = new IPickable[BagSize];
				handsContent = new IPickable[2];
				myAnimManager = gameObject.Ext_GetBehaviourWithInterface<IAnimationManager> ();
		}

		//Tries to store the pickable. Returns true if success, false if fail
		public bool StorePickable (IPickable a_pickable)
		{
				if (a_pickable._Size <= GetRemainingRoom ()) {
						for (int i=0; i<BagSize; i++) {
								if (bagContent [i] == null) {
										bagContent [i] = a_pickable;
										a_pickable._BeStored ();
										if (OVR_Helper.UsingOVR)
												AutoEquip ();
										return true;
								}
						}
						//Code should never reach this line
						return false;
				} else {
						return false;
				}
		}

		//Takes object IPickable away from inventory and returns it. Returns null if selectedIndex is empty
		public IPickable RetrievePickable (int a_index)
		{
				IPickable r_pickable = bagContent [a_index];
				if (r_pickable != null) {
						bagContent [a_index] = null;
						OrderContent ();
						r_pickable._BeRetrieved ();
						return r_pickable;
				} else {
						return null;
				}
		}

		//Places something from inventory in a hand
		public void PlaceInHand (int a_inventoryIndex, int a_handIndex)
		{
				IPickable t_auxiliar = handsContent [a_handIndex];
				bool t_isFull = t_auxiliar != null ? true : false;

				IPickable t_newEquipedIPickable = RetrievePickable (a_inventoryIndex);
				handsContent [a_handIndex] = t_newEquipedIPickable;

				//Place in hand
				if (t_newEquipedIPickable != null) {
						t_newEquipedIPickable._Place (a_handIndex == 0 ? LeftHand : RightHand, t_newEquipedIPickable._EquipPosition, true, a_handIndex);
						t_newEquipedIPickable._Equiped = true;
						myAnimManager._Equip (a_handIndex, t_newEquipedIPickable);
				}

				//Hand is already full, exchange items
				if (t_isFull) {
						StorePickable (t_auxiliar);

						if (t_newEquipedIPickable == null) //No new object equip, run _Unequip
								myAnimManager._Unequip (a_handIndex);
				}
		}

		//Reorders inventory to prevent gaps between content
		void OrderContent ()
		{
				IPickable[] t_newArray = new IPickable[BagSize];
				int t_index = 0;
				foreach (IPickable b_pickable in bagContent) {
						if (b_pickable != null) {
								t_newArray [t_index++] = b_pickable;
						}
				}
				bagContent = t_newArray;
		}
	
		int GetRemainingRoom ()
		{
				int r_room = BagSize;
				foreach (IPickable b_pickable in bagContent) {
						if (b_pickable != null) {
								r_room -= b_pickable._Size;
						}
				}

				return r_room;
		}

		void AutoEquip ()
		{
				PlaceInHand (0, handsContent [0] == null ? 0 : 1);
		}
}
