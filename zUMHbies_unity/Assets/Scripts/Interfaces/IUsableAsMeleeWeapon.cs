using UnityEngine;
using System.Collections;

public interface IUsableAsMeleeWeapon
{
		float _Sharpness {
				get;
				set;
		}

		float _BaseDamage {
				get;
				set;
		}

		float _TotalDamage {
				get;
		}
	
		/*bool _TwoHandsinUse { //false, one hand, true, two hands
				get;
				set; 
		}*/

		bool _DoesDamage { //Will be set as true if it is currently doing damage
				get;
				set;
		}	
}
