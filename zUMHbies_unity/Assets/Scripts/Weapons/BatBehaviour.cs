using UnityEngine;
using System.Collections;

public class BatBehaviour : MonoBehaviour, IInteractive, IPickable
{
		public int Size;
		public string Name;
		public Texture2D Picture;
		private bool inUsage;

		//Interface members
		public int _Size {
				get {
						return Size;
				}
				set {
						Size = value;
				}
		}
		public bool _inUsage {
			get {
				return inUsage;
			}
			set {
				inUsage = value;
			}
		}
		public string _Name {
				get {
						return Name;
				}
		}
		public Texture2D _Picture {
				get {
						return Picture;
				}
				set {
						Picture = value;
				}
		}

		// Use this for initialization
		void Start ()
		{
			inUsage = false;
	
		}
		public void _Activate (){
		print (name + " is activated");
		}
		public void _BeStored ()
		{
				gameObject.SetActive (false);
				transform.localRotation = Quaternion.identity;
		}

		public void _BeRetrieved ()
		{
				gameObject.SetActive (true);
		}

		public void _Place (Transform a_parent, Vector3 a_coordinates, bool a_beKinematic = false)
		{
				transform.parent = a_parent;
				transform.localPosition = a_coordinates;
				rigidbody.isKinematic = a_beKinematic;
		}
}
