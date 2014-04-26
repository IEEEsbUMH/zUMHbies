using UnityEngine;
using System.Collections;

public interface IAnimationManager
{
		void _Equip (int a_handIndex, IPickable a_pickable);
		void _Use (int a_handIndex);
		void _Unequip (int a_handIndex);
		void _SimpleAttack ();
}
