using UnityEngine;
using System.Collections;

public interface IInteractive
{
		Material _OutlinedMaterial {
				get;
		}

		int _OutlinedMaterialIndex {
				get;
		}

		Renderer _RendererTarget {
				get;
		}

		void _Activate ();
		void _SetAsActiveIInteractive (bool a_active);
}
