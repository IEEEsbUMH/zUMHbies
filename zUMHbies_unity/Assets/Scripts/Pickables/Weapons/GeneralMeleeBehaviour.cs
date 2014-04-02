using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneralMeleeBehaviour : GeneralPickableBehaviour, IUsableAsMeleeWeapon
{
		public float Sharpness;
		public float BaseDamage;

		protected bool DoesDamage;

		protected List<IDamageable> damagedThisAttack;

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
				//Animation handled
		}
		//END OF IUsableAsMeleeWeapon MEMBERS

		protected override void Start ()
		{
				base.Start ();

		}

		public void StartAttack ()
		{
				_DoesDamage = true;
				damagedThisAttack = new List<IDamageable> ();
		}

		public void EndAttack ()
		{
				_DoesDamage = false;
		}

		void OnTriggerEnter (Collider a_collider)
		{
				if (!_DoesDamage)
						return;

				//Look for an IDamageable still not hit and act on it
				IDamageable t_hitDamageable = a_collider.gameObject.Ext_GetClosestBehaviourWithInterfaceInHierarchy<IDamageable> ();
				if (t_hitDamageable != null && !damagedThisAttack.Contains (t_hitDamageable)) {
						t_hitDamageable._TakeDamage (_TotalDamage, default(Vector3));
						damagedThisAttack.Add (t_hitDamageable);
				}
		}
	
}
