using UnityEngine;
using System.Collections;

public interface IKillable
{
		int MaxHealth {
				get;
				set;
		}

		float health {
				get;
				set;
		}

		void TakeDamage (float a_damage);
		void Die ();
}
