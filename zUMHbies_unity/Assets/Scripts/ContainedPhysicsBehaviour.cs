using UnityEngine;
using System.Collections;

public class ContainedPhysicsBehaviour : MonoBehaviour
{
		public bool AlwaysUseOwnCollider;
		
		private float rigidbodyMass; //Required if AlwaysUseOwnCollider, due to the need to remove/readd the rigidbody component

		// Use this for initialization
		void Start ()
		{
				if (AlwaysUseOwnCollider && rigidbody != null) {
						rigidbodyMass = rigidbody.mass;
						Destroy (rigidbody);
				}

				if (collider != null)
						collider.enabled = AlwaysUseOwnCollider;
				if (rigidbody != null)
						rigidbody.isKinematic = true;
		}
	

		public void SetFree ()
		{
				transform.parent = transform.parent.parent; //Transform goes up one level in the hierarchy

				if (AlwaysUseOwnCollider) {
						gameObject.AddComponent<Rigidbody> ();
						rigidbody.mass = rigidbodyMass;
						return;
				}

				if (rigidbody != null) //The transform is in world space
						rigidbody.isKinematic = false;
				else
						print ("Warning: GameObject " + name + " does not have a rigidbody attached");

				if (collider != null)
						collider.enabled = true;
				else
						print ("Warning: GameObject " + name + " does not have a collider attached");
		}
}
