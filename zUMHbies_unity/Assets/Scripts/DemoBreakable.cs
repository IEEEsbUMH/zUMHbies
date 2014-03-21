using UnityEngine;
using System.Collections;

public class DemoBreakable : GeneralInteractiveBehaviour
{

		public override void _Activate ()
		{
				base._Activate ();
				gameObject.Ext_Separate ();
		}
}
