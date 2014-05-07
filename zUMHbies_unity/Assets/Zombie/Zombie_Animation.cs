using UnityEngine;
using System.Collections;

public class Zombie_Animation : MonoBehaviour {
	// Use this for initialization
	protected bool Detected;
	public Animator Animation_Zombie;
	public int Number_Aleatori;
	//Mask
	public bool AttackOut;
	//Distance PlayerZombie
	protected GameObject Player;
	public float Length;
	public bool AttackIn;
	protected bool Damage;
	public float SizeCharacterController;
	public float PositionControllerColliderCenter;
	public float SizeCapsuleCollider;
	public float PositionCapsuleColliderCenter;
	public float RadiusCapsule;
	protected CharacterController Controller;
	protected CapsuleCollider Collider;
	public GameObject CapsuleCollider;
	public float AxisH;
	protected float AxisV;
	protected ZombieBasicBehaviour myBehaviour;

	void Start () {
		Player = GameObject.Find ("Human");
		InvokeRepeating ("Randomizar",1,4);
		Animation_Zombie = GetComponent<Animator> ();
		Animation_Zombie.SetLayerWeight (1, 3f);
		Animation_Zombie.SetLayerWeight (2, 3f);
		Animation_Zombie.SetLayerWeight (3, 3f);
	    Controller = GetComponent<CharacterController>();
		Collider = CapsuleCollider.gameObject.transform.GetComponent<CapsuleCollider>();
		myBehaviour = GetComponent<ZombieBasicBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		Detected = this.gameObject.GetComponent<ZombieBasicBehaviour> ().chasingPlayer;
		Length=Vector3.Distance (this.gameObject.transform.position, Player.transform.position);
		if (Detected == true) {
			Animation_Zombie.SetBool ("look",true);
				} 
		else {
			Animation_Zombie.SetBool ("look",false);
				}
		if (Number_Aleatori >= 5&&Detected == true) {
			Animation_Zombie.SetBool ("floor",true);
		}
		if (Number_Aleatori < 5&&Detected == true) {
			Animation_Zombie.SetBool ("floor",false);
		}
		//Mask
		if (AttackOut == true&&Detected==true) {
						Animation_Zombie.SetBool ("AttackOut", true);
				} else {
						Animation_Zombie.SetBool ("AttackOut", false);
				}
		//Distance to Player and figth

		if (Length <= 2&&Length>1) {
						AttackOut = true;
			            AttackIn=false;
			            Animation_Zombie.SetBool ("AttackIn", false);
				} 
		else {
			AttackOut=false;
				}
		if (Length <= 1) {
			AttackIn=true;
			Animation_Zombie.SetBool ("AttackIn", true);
				}
		//Cerca
		AxisH=Input.GetAxis ("Horizontal");
		AxisV=Input.GetAxis ("Vertical");
		if (Length <= 3.5 && (AxisH > 0.8 || AxisH < -0.8 || AxisV > 0.8 || AxisV < -0.8)) {
			myBehaviour.CallFunction();
			//Debe de llamar a protected IEnumerator chasePlayer ()
		}
		//Damage
		Damage = this.gameObject.GetComponent<ZombieBasicBehaviour> ().Damage;
		if (Damage == true) {
						Animation_Zombie.SetBool ("Damage", true);
			            Animation_Zombie.SetBool ("AttackOut", false);
				} else {
						Animation_Zombie.SetBool ("Damage", false);			           
				}
		//ColliderSize
		if (Number_Aleatori >= 5 && Detected == true) {
						Controller.height = SizeCharacterController;
			            Controller.center = new Vector3 (0, PositionControllerColliderCenter, 0);
			            Controller.radius = RadiusCapsule;
			            Collider.height = SizeCapsuleCollider;
			            Collider.center = new Vector3 (0, PositionCapsuleColliderCenter, 0);
			            Collider.radius=RadiusCapsule;
		} else {
			            Controller.height = 0.8f;
			            Controller.center = new Vector3 (0, 0, 0);
			            Collider.height = 0.3f;
			            Collider.center = new Vector3 (0, 0, 0);
			            Controller.radius = 0.6f;
			            Collider.radius=0.6f;
		}
	}
	void Randomizar(){
		if (AttackIn == false&&Damage==false) {
						Number_Aleatori = Random.Range (1, 10);
				}
		}
}