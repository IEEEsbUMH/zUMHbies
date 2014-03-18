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

		//Does not work so far
		/*public static MonoBehaviour Ext_GetBehaviourWithInterface<a_interfaceName> (this GameObject a_gameObject) where a_interfaceName : class
		{
				MonoBehaviour[] t_scriptComponents = a_gameObject.GetComponents<MonoBehaviour> ();

				a_interfaceName t_candidate;
				foreach (MonoBehaviour b_behaviour in t_scriptComponents) {
						t_candidate = b_behaviour as a_interfaceName;
						if (t_candidate != null) {
								return t_candidate as MonoBehaviour;
						}
				}

				//Nothing returned so far, return null
				return null;
		}*/

		public static bool Ext_Exists (this Object a_object)
		{
				return (a_object != null);
		}
}
