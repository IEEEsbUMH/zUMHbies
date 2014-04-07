using UnityEngine;
using System.Collections;

public class ItemUseSystem : MonoBehaviour
{	
		private ItemManagement myItemManagement;
		private IAnimationManager myAnimManager;

		void Start ()
		{
				myItemManagement = GetComponent<ItemManagement> ();
				myAnimManager = gameObject.Ext_GetBehaviourWithInterface<IAnimationManager> ();
		}

		void Update ()
		{
				if (Input.GetButtonDown ("UseLeft"))
						usePickable (0);
				
				if (Input.GetButtonDown ("UseRight"))
						usePickable (1);
		}

		void usePickable (int a_handIndex)
		{
				IPickable t_pickable = myItemManagement.handsContent [a_handIndex] as IPickable;
				if (t_pickable != null) {
						t_pickable._BeUsed ();
				}
				myAnimManager._Use (a_handIndex);
		}
}
