using UnityEngine;
using System.Collections;

public interface IDamageable
{
		GameObject _OwnedBy {
				get;
				set;
		}

		void _TakeDamage (float a_damage, Vector3 a_hitPoint);
}
