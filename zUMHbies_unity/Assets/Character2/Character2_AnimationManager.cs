using UnityEngine;
using System.Collections;

public class Character2_AnimationManager : MonoBehaviour, IAnimationManager
{
		protected Animator myAnimator;
		protected ItemManagement myItemManagement;

		public HandAsWeapon LeftHandAsWeapon;
		public HandAsWeapon RightHandAsWeapon;

		void Start ()
		{
				myAnimator = GetComponent<Animator> ();
				myItemManagement = GetComponent<ItemManagement> ();
		}

		void FixedUpdate ()
		{
			
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
						myAnimator.SetTrigger (HashIDs.AddFlashlight);
						break;
			
				default:
			
						break;
				}
		}

		public void _Use (int a_handIndex)
		{
				if (Random.Range (0, 2) < 1)
						myAnimator.SetTrigger (HashIDs.Attack_Two);
				if (a_handIndex == 0) { //Left hand
						myAnimator.SetTrigger (HashIDs.Use);
						myAnimator.SetTrigger (HashIDs.Arm_L_Action);
				} else if (a_handIndex == 1) { //Right hand
						myAnimator.SetTrigger (HashIDs.Use);
						myAnimator.SetTrigger (HashIDs.Arm_R_Action);
				}
		}

		public void _SimpleAttack ()
		{
				myAnimator.SetTrigger (HashIDs.Punch);
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

				if (t_meleeWeapon != null)
						t_meleeWeapon._DoesDamage = true;
				else {
						if (a_handIndex == 0)
								LeftHandAsWeapon._DoesDamage = true;
						else if (a_handIndex == 1)
								RightHandAsWeapon._DoesDamage = true;
				}
		}

		public void AE_DamageOff (int a_handIndex)
		{
				IUsableAsMeleeWeapon t_meleeWeapon = myItemManagement.handsContent [a_handIndex] as IUsableAsMeleeWeapon;

				if (t_meleeWeapon != null)
						t_meleeWeapon._DoesDamage = false;
				else {
						if (a_handIndex == 0)
								LeftHandAsWeapon._DoesDamage = false;
						else if (a_handIndex == 1)
								RightHandAsWeapon._DoesDamage = false;
				}
		}

		public void AE_InteractionComplete ()
		{
			
		}
}
