using UnityEngine;
using System.Collections;

public class ItemManagement : MonoBehaviour
{

		public int BagSize;
		public IPickable[] bagContent;
		public IPickable[] handsContent;

		// Use this for initialization
		void Start ()
		{
				bagContent = new IPickable[BagSize];
				handsContent = new IPickable[2];
		}
	
		public bool StorePickable (IPickable a_pickable)
		{
				if (a_pickable.Size <= GetRemainingRoom ()) {
						for (int i=0; i<BagSize; i++) {
								if (bagContent [i] == null) {
										bagContent [i] = a_pickable;
										return true;
								}
						}
						//Code should never reach this line
						return false;
				} else {
						return false;
				}
		}

		//Takes object IPickable away from inventory and returns it
		public IPickable RetrievePickable (int a_index)
		{
				IPickable r_pickable = bagContent [a_index];
				bagContent [a_index] = null;
				OrderContent ();
				return r_pickable;
		}

		//Places something from inventory in a hand
		public void PlaceInHand (int a_inventoryIndex, int a_handIndex)
		{
				IPickable t_auxiliar = handsContent [a_handIndex];
				handsContent [a_handIndex] = RetrievePickable (a_inventoryIndex);

				//Hand is already full, exchange items
				if (handsContent [a_handIndex] != null) {
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
								r_room -= b_pickable.Size;
						}
				}

				return r_room;
		}
}
