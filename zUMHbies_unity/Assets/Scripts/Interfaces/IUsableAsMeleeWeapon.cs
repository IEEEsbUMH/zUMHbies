using UnityEngine;
using System.Collections;

public interface IUsableAsMeleeWeapon
{
		float Sharpness {
				get;
				set;
		}
	
		bool TwoHandsinUse { //false, one hand, true, two hands
				get;
				set; 
		}
}
