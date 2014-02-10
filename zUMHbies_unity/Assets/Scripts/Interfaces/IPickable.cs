using UnityEngine;
using System.Collections;

public interface IPickable
{
		int Size {
				get;
				set;
		}

		string Name {
				get;
				set;
		}

		Texture2D Picture {
				get;
				set;
		}
}