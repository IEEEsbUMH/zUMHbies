public interface IBreakable
{
		int _MaxIntegrity {
				get;
				set;
		}

		float _Integrity {
				get;
				set;
		}

		void _Break ();
		void _TakeDamage (float a_damage);
}