using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandAsWeapon : MonoBehaviour, IUsableAsMeleeWeapon
{
		//IUsableAsMeleeWeapon members
		public float _Sharpness {
				get;
				set;
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
						return BaseDamage;
				}
		}

		public bool _DoesDamage {
				get {
						return doesDamage;
				}
				set {
						doesDamage = value;
						if (value) {
								StartAttack ();
								collider.enabled = true;
						} else {
								EndAttack ();
								collider.enabled = false;
						}
				}
		}

		public GameObject _OwnedBy {
				get;
				set;
		}
		//END OF IUsableAsMeleeWeapon MEMBERS
		public bool ControlledByAnimation;

		public float BaseDamage;
		protected bool doesDamage;
		protected List<IDamageable> damagedThisAttack;

		void Start ()
		{
				_OwnedBy = gameObject.Ext_GetTopParent ();
				damagedThisAttack = new List<IDamageable> ();
		}

		public void StartAttack ()
		{
				//_DoesDamage = true;
				damagedThisAttack = new List<IDamageable> ();
		}
	
		public void EndAttack ()
		{
				//_DoesDamage = false;
		}

		void OnTriggerEnter (Collider a_collider)
		{
				//Look for an IDamageable still not hit and act on it
				IDamageable t_hitDamageable = a_collider.gameObject.Ext_GetClosestBehaviourWithInterfaceInHierarchy<IDamageable> ();

				//print (t_hitDamageable._OwnedBy);
				if (t_hitDamageable != null && t_hitDamageable._OwnedBy != _OwnedBy && !damagedThisAttack.Contains (t_hitDamageable)) {
						t_hitDamageable._TakeDamage (_TotalDamage, transform.position);
						print ("ouch");

						if (ControlledByAnimation)
								damagedThisAttack.Add (t_hitDamageable);
				}
		}
}
