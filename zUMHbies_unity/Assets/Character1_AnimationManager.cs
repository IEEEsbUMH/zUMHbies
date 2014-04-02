using UnityEngine;
using System.Collections;

public class Character1_AnimationManager : MonoBehaviour, IAnimationManager
{
		protected Animator myAnimator;

		void Start ()
		{
				myAnimator = GetComponent<Animator> ();
		}

		void FixedUpdate ()
		{
			
		}

		public void _Equip (int a_handIndex, IPickable a_pickable)
		{
				if (a_handIndex == 0) { //Left hand
						switch (a_pickable._AnimID) {
						case AnimIDs.BAT:
								myAnimator.SetTrigger (HashIDs.AddBat_L);
								break;

						case AnimIDs.FLASHLIGHT:

								break;

						default:
					
								break;
						}
				} else if (a_handIndex == 1) { //Right hand

				}
		}

		public void _Use (int a_handIndex)
		{
				if (a_handIndex == 0) { //Left hand
						myAnimator.SetTrigger (HashIDs.Use_L);
				} else if (a_handIndex == 1) { //Right hand
				
				}
		}

		//Event receivers
		public void AE_DamageOn ()
		{
				
		}

		public void AE_DamageOff ()
		{

		}
}
