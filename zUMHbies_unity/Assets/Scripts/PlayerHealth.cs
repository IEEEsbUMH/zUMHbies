using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IKillable
{
		[SerializeField]
		protected int
				maxHealth;

		public int _MaxHealth {
				set;
				get;
		}
		public float _Health {
				get;
				set;
		}

		public GameObject _OwnedBy {
				get;
				set;
		}

		public void _Die ()
		{
				GameObject.FindGameObjectWithTag (Tags.GAME_CONTROLLER).GetComponent<GameControl> ().EndGame ();
		}

		public void _TakeDamage (float a_damage, Vector3 a_hitPoint)
		{
				//print ("ouch");
				_Health -= a_damage;
				if (_Health <= 0)
						_Die ();
		}

		void Start ()
		{
				_OwnedBy = gameObject.Ext_GetTopParent ();
				_Health = maxHealth;
		}
}
