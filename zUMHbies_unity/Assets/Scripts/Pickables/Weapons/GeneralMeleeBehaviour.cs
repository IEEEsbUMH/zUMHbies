using UnityEngine;
using System.Collections;

public class GeneralMeleeBehaviour : GeneralPickableBehaviour, IUsableAsMeleeWeapon
{
		public float Sharpness;
		public float BaseDamage;

		protected bool DoesDamage;

		protected IDamageable[] damagedLastAttack;

		//IUsableAsMeleeWeapon members
		public float _Sharpness {
				get {
						return Sharpness;
				}

				set {
						Sharpness = value;
				}
		}

		public float _BaseDamage {
				get {
						return BaseDamage;
				}
				set {
						BaseDamage = value;
				}
		}

		public float _TotalDamage {
				get {
						return (_Sharpness + _BaseDamage);
				}
		}

		public bool _DoesDamage {
				get {
						return DoesDamage;
				}

				set {
						DoesDamage = value;
						//Enable or disables the collider
						collider.enabled = value ? true : false;
				}
		}
		
	
		public override void _BeUsed ()
		{
				//If not attacking currently, we start a new attack
				if (!DoesDamage)
						startAttack ();
		}
		//END OF IUsableAsMeleeWeapon MEMBERS

		protected override void Start ()
		{
				base.Start ();
				print (DoesDamage);
		}

		void startAttack ()
		{
				_DoesDamage = true;
				damagedLastAttack = new IDamageable[2];
		}

		void endAttack ()
		{
				_DoesDamage = false;
		}

		void OnTriggerEnter (Collider a_collider)
		{

				print (a_collider.gameObject);
				//Look for a IDamageable
				IDamageable t_hitDamageable = a_collider.gameObject.Ext_GetClosestBehaviourWithInterfaceInHierarchy<IDamageable> ();
				if (t_hitDamageable != null)
						t_hitDamageable._TakeDamage (_TotalDamage);



				/*if (damagedLastAttack) {

				}*/
		}
	
}
