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
		//END OF IUsableAsMeleeWeapon MEMBERS

		public float BaseDamage;
		protected bool doesDamage;
		protected List<IDamageable> damagedThisAttack;

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
				if (!_DoesDamage)
						return;
		
				//Look for an IDamageable still not hit and act on it
				IDamageable t_hitDamageable = a_collider.gameObject.Ext_GetClosestBehaviourWithInterfaceInHierarchy<IDamageable> ();
		
				if (t_hitDamageable != null && !damagedThisAttack.Contains (t_hitDamageable)) {
						t_hitDamageable._TakeDamage (_TotalDamage, transform.position);
						//print ("ouch");
						damagedThisAttack.Add (t_hitDamageable);
				}
		}
}
