using UnityEngine;
using System.Collections;

public class FlashlightBehaviour : GeneralPickableBehaviour
{
		public Light LightComponent;
		public Collider LightTrigger;

		/*public delegate void OffDelegate ();
		public event OffDelegate OnSwitchOff;*/
		

		public override void _Activate ()
		{
				on_off ();
		}

		public override void _BeUsed ()
		{
				on_off ();
		}

		private void on_off ()
		{
				LightComponent.enabled = !LightComponent.enabled;
				LightTrigger.enabled = !LightTrigger.enabled;

				/*if (OnSwitchOff != null && LightTrigger.enabled) {
						OnSwitchOff ();
				}*/
		}
}
