using UnityEngine;
using System.Collections;

public class GeneralBreakableBehaviour : MonoBehaviour, IBreakable
{
		public int MaxIntegrity;

		protected float integrity;


		//IBreakable members
		public int _MaxIntegrity {
				get {
						return MaxIntegrity;
				}
				set {

				}
		}
		public float _Integrity {
				get {
						return integrity;
				}
				set {
						integrity = value;
				}
		}

		public void _TakeDamage (float a_damage)
		{
				integrity -= a_damage;
				print (integrity);

				if (integrity <= 0)
						_Break ();
		}

		public void _Break ()
		{
				gameObject.Ext_Separate ();
		}
		//END OF IBreakable MEMBERS

		void Start ()
		{
				integrity = MaxIntegrity;
		}
}
