using UnityEngine;
using System.Collections;

public class Character1_AnimationManager : MonoBehaviour, IAnimationManager
{
		protected Animator myAnimator;
		protected ItemManagement myItemManagement;

		void Start ()
		{
				myAnimator = GetComponent<Animator> ();
				myItemManagement = GetComponent<ItemManagement> ();
		}

		/*void FixedUpdate ()
		{
			
		}*/

		public void _Equip (int a_handIndex, IPickable a_pickable)
		{
				if (a_handIndex == 0) { //Left hand
						myAnimator.SetTrigger (HashIDs.Arm_L_Action);
				} else if (a_handIndex == 1) { //Right hand
						myAnimator.SetTrigger (HashIDs.Arm_R_Action);
				}

				switch (a_pickable._AnimID) {
				case AnimIDs.BAT:
						myAnimator.SetTrigger (HashIDs.AddBat);
						break;
			
				case AnimIDs.FLASHLIGHT:
			
						break;
			
				default:
			
						break;
				}
		}

		public void _Use (int a_handIndex)
		{
				if (a_handIndex == 0) { //Left hand
						myAnimator.SetTrigger (HashIDs.Use);
						myAnimator.SetTrigger (HashIDs.Arm_L_Action);
				} else if (a_handIndex == 1) { //Right hand
						myAnimator.SetTrigger (HashIDs.Use);
						myAnimator.SetTrigger (HashIDs.Arm_R_Action);
				}
		}

		public void _Unequip (int a_handIndex)
		{
				if (a_handIndex == 0) { //Left hand
						myAnimator.SetTrigger (HashIDs.Unequip);
						myAnimator.SetTrigger (HashIDs.Arm_L_Action);
				} else if (a_handIndex == 1) { //Right hand
						myAnimator.SetTrigger (HashIDs.Unequip);
						myAnimator.SetTrigger (HashIDs.Arm_R_Action);
				}
		}

		//Event receivers
		public void AE_DamageOn (int a_handIndex)
		{
				IUsableAsMeleeWeapon t_meleeWeapon = myItemManagement.handsContent [a_handIndex] as IUsableAsMeleeWeapon;
				t_meleeWeapon._DoesDamage = true;
		}

		public void AE_DamageOff (int a_handIndex)
		{
				IUsableAsMeleeWeapon t_meleeWeapon = myItemManagement.handsContent [a_handIndex] as IUsableAsMeleeWeapon;
				t_meleeWeapon._DoesDamage = false;
		}
}
