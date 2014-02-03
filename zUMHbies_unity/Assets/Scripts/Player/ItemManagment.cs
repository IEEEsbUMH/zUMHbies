using UnityEngine;
using System.Collections;

public class ItemManagement : MonoBehaviour
{

		public int BagSize;
		private IPickable[] bagContent;

		// Use this for initialization
		void Start ()
		{
				bagContent = new IPickable[BagSize];
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

		public IPickable RetrievePickable (int a_index)
		{
				IPickable r_pickable = bagContent [a_index];
				bagContent [a_index] = null;
				OrderContent ();
				return r_pickable;
		}

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
