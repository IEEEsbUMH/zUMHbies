using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{
		public static void Ext_Separate (this GameObject a_gameObject)
		{
				if (a_gameObject.collider != null)
						a_gameObject.collider.enabled = false;

				int t_initialChildren = a_gameObject.transform.childCount;
				for (int i=0; i<t_initialChildren; i++) {
						ContainedPhysicsBehaviour behaviour = a_gameObject.transform.GetChild (0).GetComponent<ContainedPhysicsBehaviour> ();
			
						if (behaviour != null) {
								behaviour.SetFree ();
						}
			
				}
				//Called in case there are some remaining objects inside the hierarchy
				a_gameObject.transform.DetachChildren ();
				Object.Destroy (a_gameObject);
		}	
}
