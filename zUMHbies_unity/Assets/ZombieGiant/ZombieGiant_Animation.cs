using UnityEngine;
using System.Collections;

public class ZombieGiant_Animation : MonoBehaviour {
	// Use this for initialization
	//Variables in two scripts
	protected bool Detected;
	protected bool busy;
	public Animator Animation_Zombie;
	public int Number_Aleatori;
	//Mask
	public bool AttackOut;
	//Distance PlayerZombie
	protected GameObject Player;
	public float Length;
	public bool AttackIn;
	protected bool Damage;
	//Near
	public float AxisH;
	protected float AxisV;
	protected ZombieGiantBasicBehaviour myBehaviour;

	void Start () {
		Player = GameObject.Find ("Human");
		Animation_Zombie = GetComponent<Animator> ();
		Animation_Zombie.SetLayerWeight (1, 2f);
		myBehaviour = GetComponent<ZombieGiantBasicBehaviour> ();
	}
	
	// Update is called once per frame
	void Update () {
		Detected = this.gameObject.GetComponent<ZombieGiantBasicBehaviour> ().chasingPlayer;
		busy = this.gameObject.GetComponent<ZombieGiantBasicBehaviour> ().busy;
		Length=Vector3.Distance (this.gameObject.transform.position, Player.transform.position);
		//Detected without bussy
		if(busy==false){
			Animation_Zombie.SetBool ("busy",false);
		if (Detected == true) {
			Animation_Zombie.SetBool ("look",true);
				} 
		else {
			Animation_Zombie.SetBool ("look",false);
				}
		}
		//Detected with bussy
		if(busy==true){
			Animation_Zombie.SetBool ("busy",true);
			if (Detected == true) {
				Animation_Zombie.SetBool ("look",true);
			} 
			else {
				Animation_Zombie.SetBool ("look",false);
			}
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
		//Near
		AxisH=Input.GetAxis ("Horizontal");
		AxisV=Input.GetAxis ("Vertical");
		if (Length <= 3.5 && (AxisH > 0.8 || AxisH < -0.8 || AxisV > 0.8 || AxisV < -0.8)) {
			myBehaviour.CallFunction();
			//Debe de llamar a protected IEnumerator chasePlayer ()
		}
		//Damage
		Damage = this.gameObject.GetComponent<ZombieGiantBasicBehaviour> ().Damage;
		if (Damage == true) {
						Animation_Zombie.SetBool ("Damage", true);
			            Animation_Zombie.SetBool ("AttackOut", false);
				} else {
						Animation_Zombie.SetBool ("Damage", false);			           
				}
	}
}