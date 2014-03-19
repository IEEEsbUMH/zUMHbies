using UnityEngine;
using System.Collections;

public interface IKillable: IDamageable
{
		int _MaxHealth {
				get;
				set;
		}

		float _Health {
				get;
				set;
		}
	
		void _Die ();
}
