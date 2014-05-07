using UnityEngine;
using System.Collections;

public class ActiveRagdollGiant : MonoBehaviour {
	public GameObject[] Box;
	public GameObject[] Capsule;
	public GameObject[] Sphere;
	protected CharacterController Controller;
	public GameObject SightCollider;
	public GameObject DamageCollider;
	protected BoxCollider BoxCollider;
	protected CapsuleCollider CapsuleCollider;
	protected SphereCollider SphereCollider;
	protected bool Die;
	public Animator Animation_Zombie;
	protected ZombieGiantBasicBehaviour myBehaviour;
	// Use this for initialization
	void Start () {
		Controller = GetComponent<CharacterController>();
		Animation_Zombie = GetComponent<Animator> ();
		myBehaviour = GetComponent<ZombieGiantBasicBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.myBehaviour == true) {
						Die = this.gameObject.GetComponent<ZombieGiantBasicBehaviour> ().Die;
				}
		if (Die == true) {
			//Destruir esto
			Destroy (Controller);
			Destroy (this.GetComponent<ZombieGiantBasicBehaviour> ());
			Destroy (this.GetComponent<ZombieGiant_Animation> ());
			Destroy (SightCollider);
			Destroy (DamageCollider);
			Animation_Zombie.enabled=false;
			//Destruir esto
			for (var a = 0; a < Box.Length; a++) {
				BoxCollider =Box [a].gameObject.transform.GetComponent<BoxCollider>();
				Box [a].rigidbody.isKinematic = false;
				BoxCollider.enabled= true;
			}
			for (var b = 0; b < Capsule.Length; b++) {
				CapsuleCollider =Capsule [b].gameObject.transform.GetComponent<CapsuleCollider>();
				Capsule [b].rigidbody.isKinematic = false;
				CapsuleCollider.enabled = true;
			}
			for (var c = 0; c < Sphere.Length; c++) {
				SphereCollider =Sphere [c].gameObject.transform.GetComponent<SphereCollider>();
				Sphere [c].rigidbody.isKinematic = false;
				SphereCollider.enabled = true;
			}
				}
	}
}
