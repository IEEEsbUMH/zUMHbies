using UnityEngine;
using System.Collections;

public class GUICamerabehaviour : MonoBehaviour
{
		protected Camera myCamera;
		protected bool renderScene;
		public bool RenderScene {
				get {
						return renderScene;
				}
				set {
						renderScene = value;
						myCamera.enabled = value;
				}
		}

		// Use this for initialization
		void Start ()
		{
				myCamera = GetComponent<Camera> ();
		}
	
		// Update is called once per frame
		void OnPostRender ()
		{
				RenderScene = false;
				myCamera.enabled = false;
		}
}
