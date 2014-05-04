using UnityEngine;
using System.Collections;

public class PushAndOpenBehaviour : GeneralSwitchBehaviour
{
		public override void _Activate ()
		{
				switchableBehaviour._Activate ();
				if (MyAnimator != null)
						MyAnimator.SetTrigger (HashIDs.Open);
		}
}
