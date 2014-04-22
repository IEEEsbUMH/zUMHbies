using UnityEngine;
using System.Collections;

[System.Serializable]
public class MovementVelocity
{
		public float crouchSpeed; //   Crouch speed always should take a number between 0 and 1 
		public float walkSpeed; //     Walk Speed always should take constant 1
		public float runSpeed; //   Run Speed always should take a value between 1 and 2
}
public class PlayerMovement : MonoBehaviour
{
		public float Speed;
		public float MouseSpeed;

		public Transform POV;
		public float MaxCameraRotation;
		public float MinCameraRotation;

		private CharacterController characterController;
		
		private bool isPlayerCrouched;
		private Vector3 translationMotion;
		private float speedType; // 3 types: Declared in MovementVelocity class 
		public MovementVelocity velocity;
		public float jumpRate; //this controls how many times per second you can jump
		public float jumpHeight; //this states how much you can jump
		private float nextJump;

		private Character2_AnimationManager myAnimationManager;
		void Start ()
		{
				characterController = GetComponent<CharacterController> ();
				myAnimationManager = GetComponent<Character2_AnimationManager> ();
				isPlayerCrouched = false;
				speedType = velocity.walkSpeed;
		}

		void FixedUpdate ()
		{
				translationMotion = new Vector3 (0f, Physics.gravity.y, 0f);

				translationInputHandling ();
				mouseMovementInputHandling ();
				crouchInputHandling ();
				runInputHandling ();
				characterController.Move (translationMotion * Time.deltaTime);
		}	

		private void translationInputHandling ()
		{
				translationMotion.x = speedType * Speed * (Input.GetAxis ("Horizontal") * Mathf.Cos (Mathf.Deg2Rad * (Vector3.Angle (Vector3.right, transform.right))) + Input.GetAxis ("Vertical") * Mathf.Cos (Mathf.Deg2Rad * (Vector3.Angle (Vector3.right, transform.forward))));
				translationMotion.z = speedType * Speed * (Input.GetAxis ("Horizontal") * Mathf.Cos (Mathf.Deg2Rad * (Vector3.Angle (Vector3.forward, transform.right))) + Input.GetAxis ("Vertical") * Mathf.Cos (Mathf.Deg2Rad * (Vector3.Angle (Vector3.forward, transform.forward))));
		}
		private void crouchInputHandling ()
		{
				/*if (Input.GetButtonDown ("Crouch")) {
						if (!isPlayerCrouched) {
								POV.transform.position = new Vector3 (POV.transform.position.x, (POV.transform.position.y - 0.4f), POV.transform.position.z);
								speedType = velocity.crouchSpeed;
								isPlayerCrouched = true;
						} else {
								POV.transform.position = new Vector3 (POV.transform.position.x, (POV.transform.position.y + 0.4f), POV.transform.position.z);
								speedType = velocity.walkSpeed;
								isPlayerCrouched = false;
						}
				}*/
		}
		private void runInputHandling ()
		{
				if (Input.GetButtonDown ("Run") && !isPlayerCrouched) {
						speedType = velocity.runSpeed;
				} else if (Input.GetButtonUp ("Run") && !isPlayerCrouched) {
						speedType = velocity.walkSpeed;
				}
		}

		private void mouseMovementInputHandling ()
		{
				if (Input.GetAxis ("Mouse Y") > 0 ? Vector3.Angle (POV.forward, transform.up) > MaxCameraRotation : Vector3.Angle (POV.forward, transform.up) < MinCameraRotation)
						rotatePOV (new Vector3 (-Input.GetAxis ("Mouse Y") * MouseSpeed * Time.deltaTime, 0, 0));
				transform.Rotate (new Vector3 (0, Input.GetAxis ("Mouse X") * MouseSpeed * Time.deltaTime, 0));
		}

		private void rotatePOV (Vector3 a_eulerAngles)
		{
				POV.Rotate (a_eulerAngles);
		}
}
