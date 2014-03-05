public interface IBreakable
{
		int MaxIntegrity {
				get;
				set;
		}

		float integrity {
				get;
				set;
		}

		void Break ();
		void TakeDamage (float a_damage);
}