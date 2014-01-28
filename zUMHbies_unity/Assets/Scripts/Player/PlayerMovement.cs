using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
		public float Speed;
		public float MouseSpeed;

		public GameObject POV;
		public float MaxCameraRotation;
		public float MinCameraRotation;

		private CharacterController characterController;

		private Vector3 translationMotion;

		void Start ()
		{
				characterController = GetComponent<CharacterController> ();
		}

		void FixedUpdate ()
		{
				translationMotion = new Vector3 (0f, Physics.gravity.y, 0f);

				translationInputHandling ();
				mouseMovementInputHandling ();

				characterController.Move (translationMotion * Time.deltaTime);
		}	

		private void translationInputHandling ()
		{
				translationMotion.x = Speed * (Input.GetAxis ("Horizontal") * Mathf.Cos (Mathf.Deg2Rad * (Vector3.Angle (Vector3.right, transform.right))) + Input.GetAxis ("Vertical") * Mathf.Cos (Mathf.Deg2Rad * (Vector3.Angle (Vector3.right, transform.forward))));
				translationMotion.z = Speed * (Input.GetAxis ("Horizontal") * Mathf.Cos (Mathf.Deg2Rad * (Vector3.Angle (Vector3.forward, transform.right))) + Input.GetAxis ("Vertical") * Mathf.Cos (Mathf.Deg2Rad * (Vector3.Angle (Vector3.forward, transform.forward))));
		}
	
		private void mouseMovementInputHandling ()
		{
				if (Input.GetAxis ("Mouse Y") > 0 ? Vector3.Angle (POV.transform.forward, transform.up) > MaxCameraRotation : Vector3.Angle (POV.transform.forward, transform.up) < MinCameraRotation)
						POV.transform.Rotate (new Vector3 (-Input.GetAxis ("Mouse Y") * MouseSpeed * Time.deltaTime, 0, 0));
				transform.Rotate (new Vector3 (0, Input.GetAxis ("Mouse X") * MouseSpeed * Time.deltaTime, 0));
		}
}
