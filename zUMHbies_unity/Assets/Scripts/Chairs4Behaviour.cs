using UnityEngine;
using System.Collections;

public class Chairs4Behaviour : MonoBehaviour, IInteractive
{

		// Use this for initialization
		void Start ()
		{
	
		}

		public void _Activate ()
		{
				Break ();
		}

		public void Break ()
		{
				collider.enabled = false;
				int t_initialChildren = transform.childCount;
				for (int i=0; i<t_initialChildren; i++) {
						ContainedPhysicsBehaviour behaviour = transform.GetChild (0).GetComponent<ContainedPhysicsBehaviour> ();
					
						if (behaviour != null) {
								behaviour.SetFree ();
						}
						
				}
				//Called in case there are some remaining objects inside the hierarchy
				transform.DetachChildren ();
				Destroy (gameObject);
		}
}
