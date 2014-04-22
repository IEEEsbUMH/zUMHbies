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
		
		public static T GetClosestComponentInHierarchy<T> (this GameObject a_gameObject) where T : Component
		{
				Transform t_currentTransform = a_gameObject.transform;
				T r_component;

				while (t_currentTransform != null) {
						r_component = t_currentTransform.GetComponent<T> ();
						if (r_component != null)
								return r_component;
						else
								t_currentTransform = t_currentTransform.parent;
				}
				return default(T);
		}
		
		public static _INTERFACE_ Ext_GetBehaviourWithInterface<_INTERFACE_> (this GameObject a_gameObject) where _INTERFACE_ : class
		{
				MonoBehaviour[] t_scriptComponents = a_gameObject.GetComponents<MonoBehaviour> ();

				_INTERFACE_ t_candidate;
				foreach (MonoBehaviour b_behaviour in t_scriptComponents) {
						t_candidate = b_behaviour as _INTERFACE_;
						if (t_candidate != null) {
								return t_candidate;
						}
				}

				//Nothing returned so far, return null
				return null;
		}

		public static _INTERFACE_ Ext_GetClosestBehaviourWithInterfaceInHierarchy <_INTERFACE_> (this GameObject a_gameObject) where _INTERFACE_ : class
		{
				bool t_stopRunning = false;
				do {
						MonoBehaviour[] t_scriptComponents = a_gameObject.GetComponents<MonoBehaviour> ();
			
						foreach (MonoBehaviour b_behaviour in t_scriptComponents) {
								_INTERFACE_ t_candidate = b_behaviour as _INTERFACE_;
								if (t_candidate != null) {
										return t_candidate; //Found target
								}
						}

						//Nothing found. Set new candidate as its parent to run the recognition code again as long as there is a parent
						if (a_gameObject.transform.parent != null)
								a_gameObject = a_gameObject.transform.parent.gameObject;
						else
								t_stopRunning = true;

				} while(!t_stopRunning) ;//Run until told the opposite

				//Nothing found up to root level. Return null
				return null;
		}

		//Returns true if there is nothing between origin and target
		public static bool Ext_DirectRay (this GameObject a_gameObject, Vector3 a_from, Vector3 a_to, Collider a_target)
		{
				RaycastHit t_hit;
				if (Physics.Raycast (a_from, a_to - a_from, out t_hit)) {
						if (t_hit.collider == a_target)
								return true;
				}

				return false;
		}

		public static bool Ext_Exists (this Object a_object)
		{
				return (a_object != null);
		}	
}
