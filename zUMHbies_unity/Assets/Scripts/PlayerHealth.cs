using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour, IKillable
{
		public int _MaxHealth {
				set;
				get;
		}
		public float _Health {
				get;
				set;
		}

		public void _Die ()
		{
				GameObject.FindGameObjectWithTag (Tags.GAME_CONTROLLER).GetComponent<GameControl> ().EndGame ();
		}

		public void _TakeDamage (float a_damage, Vector3 a_hitPoint)
		{
				_Health -= a_damage;
		}
}
