using UnityEngine;
using System.Collections;

public class PushRigidbody : MonoBehaviour
{
		const float PushPower = 0.5f;
		public float Mass = 0f;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		void OnControllerColliderHit (ControllerColliderHit a_hit)
		{
				Rigidbody t_hitBody = a_hit.collider.attachedRigidbody;
				if (t_hitBody == null || t_hitBody.isKinematic) {
						return;
				}

				Vector3 t_pushDirection = new Vector3 (a_hit.moveDirection.x, 0, a_hit.moveDirection.z);
				//t_hitBody.velocity = t_pushDirection * Mass * PushPower;
				t_hitBody.AddForceAtPosition (t_pushDirection * Mass * PushPower, a_hit.point);
		}
}
