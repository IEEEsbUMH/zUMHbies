using UnityEngine;
using System.Collections;

public class ItemUseSystem : MonoBehaviour
{
	
		private ItemManagement myItemManagement;

		void Start ()
		{
				myItemManagement = GetComponent<ItemManagement> ();
		}

		void Update ()
		{
				if (Input.GetButtonDown ("UseLeft"))
						usePickable (0);
				
				if (Input.GetButtonDown ("UseLeft"))
						usePickable (1);
		}

		void usePickable (int a_index)
		{
				IPickable t_pickable = myItemManagement.handsContent [a_index] as IPickable;
				if (t_pickable != null) {
						t_pickable._BeUsed ();
				}
		}
}
