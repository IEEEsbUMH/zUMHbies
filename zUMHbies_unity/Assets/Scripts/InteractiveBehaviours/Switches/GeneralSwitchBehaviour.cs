using UnityEngine;
using System.Collections;

public class GeneralSwitchBehaviour : GeneralInteractiveBehaviour
{
		public GameObject Target;
		public Animator MyAnimator;
		protected ISwitchable switchableBehaviour;

		public override void Start ()
		{
				base.Start ();
				MonoBehaviour[] t_behaviours = Target.GetComponents<MonoBehaviour> ();

				foreach (MonoBehaviour b_behaviour in t_behaviours) {
						switchableBehaviour = b_behaviour as ISwitchable;

						if (switchableBehaviour != null)
								break;
				}
				if (switchableBehaviour == null) {
						print ("Warning: " + name + " did not find an ISwitchable behaviour to activate");
				}
		}

		public override void _Activate ()
		{
				//Do something in switchableBehaviour
		}
}
