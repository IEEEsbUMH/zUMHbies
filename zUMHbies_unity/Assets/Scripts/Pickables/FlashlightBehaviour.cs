using UnityEngine;
using System.Collections;

public class FlashlightBehaviour : GeneralPickableBehaviour
{
		public Light LightComponent;
		// Use this for initialization
		void Start ()
		{
	
		}

		// Update is called once per frame
		void Update ()
		{
	
		}

		public override void _Activate ()
		{
				on_off ();
		}

		private void on_off ()
		{
				LightComponent.enabled = !LightComponent.enabled;
		}
}
