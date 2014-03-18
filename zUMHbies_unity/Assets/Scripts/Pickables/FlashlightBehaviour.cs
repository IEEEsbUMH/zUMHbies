using UnityEngine;
using System.Collections;

public class FlashlightBehaviour : GeneralPickableBehaviour
{
		public Light LightComponent;
		

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
		}
}
