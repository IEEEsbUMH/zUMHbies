using UnityEngine;
using System.Collections;

public class dropBlood : MonoBehaviour
{
	public GameObject bloodParticle;
	public float bleedingTime;
	private float bleedNext;
	public float bleedRate;
	private CharacterController characterController;
	private float slightMovement;
	void Start (){
		characterController = GetComponent<CharacterController> ();
		bleedNext=0f;
		slightMovement = 0.000000000001f;
	}
	void FixedUpdate()
	{
		//This slight movement is needed to call OnControllerColliderHit even when the object is not "moving"
		characterController.SimpleMove(new Vector3(slightMovement,0f,0f));
		characterController.SimpleMove(new Vector3(-slightMovement,0f,0f));
	}
	void OnControllerColliderHit (ControllerColliderHit hit)
	{
		if (hit.gameObject.tag != "Weapon") {
						return;
				} else if (Time.time >= bleedNext) {
						Vector3 pos = new Vector3 (hit.point.x, (hit.point.y + 0.5f), hit.point.z);
						bleedNext = Time.time + bleedRate;
						var bloodrip = Instantiate (bloodParticle, pos, Quaternion.identity) as GameObject;
						bloodrip.transform.parent = transform;
						Destroy (bloodrip, bleedingTime);
				} else{
						return;
				}
	}
}
