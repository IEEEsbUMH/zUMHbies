using UnityEngine;
using System.Collections;

public class ItemManagement : MonoBehaviour
{

		public int BagSize;
		public IPickable[] bagContent;
		public IPickable[] handsContent; //0 for left, 1 for right

		// Use this for initialization
		void Start ()
		{
				bagContent = new IPickable[BagSize];
				handsContent = new IPickable[2];
		}

		//Tries to store the pickable. Returns true if success, false if fail
		public bool StorePickable (IPickable a_pickable)
		{
				if (a_pickable._Size <= GetRemainingRoom ()) {
						for (int i=0; i<BagSize; i++) {
								if (bagContent [i] == null) {
										bagContent [i] = a_pickable;
										a_pickable._BeStored ();
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

				handsContent [a_handIndex] = RetrievePickable (a_inventoryIndex);

				//Place in hand
				if (handsContent [a_handIndex] != null) {
						handsContent [a_handIndex]._Place (transform, new Vector3 (a_handIndex == 0 ? -0.75f : 0.75f, 0, 1), true);
				}

				//Hand is already full, exchange items
				if (t_isFull) {
						StorePickable (t_auxiliar);
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
}
