public interface IBreakable: IDamageable
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
}