using UnityEngine;
using System.Collections;

public class GeneralPickableBehaviour : MonoBehaviour, IInteractive, IPickable
{
		//Members
		public int Size;
		public string Name;
		public Texture2D Picture;

		public Vector3 DropRotation; //Rotation in euler angles, will be converted to quaternion when asked for _DropRotation
		public Vector3 EquipRotation; //Same

		//IPickable member
		public int _Size {
				get {
						return Size;
				}
				set {
						Size = value;
				}
		}

		public string _Name {
				get {
						return Name;
				}
				set {
						name = value;
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

		public Quaternion _DropRotation {
				get {
						return Quaternion.Euler (DropRotation);
				}
		}

		public Quaternion _EquipRotation {
				get {
						return Quaternion.Euler (DropRotation);
				}
		}

		public virtual void _Activate ()
		{
				print (Name + " has been activated");
		}

		public virtual void _BeStored ()
		{
				gameObject.SetActive (false);
				//transform.localRotation = Quaternion.identity;
		}

		public virtual void _BeRetrieved ()
		{
				gameObject.SetActive (true);
		}

		public void _Place (Transform a_parent, Vector3 a_coordinates, bool a_beKinematic = false)
		{
				//No parent, so the pickable is dropped
				if (a_parent == null) {
						transform.localEulerAngles = DropRotation;
				} else {//Parented, so the pickable is equipped
						transform.localEulerAngles = EquipRotation;
				}

				transform.parent = a_parent;
		
				transform.localPosition = a_coordinates;
				rigidbody.isKinematic = a_beKinematic;

				//Repeat code to avoid weird bug
				//No parent, so the pickable is dropped
				if (a_parent == null) {
						transform.localEulerAngles = DropRotation;
				} else {//Parented, so the pickable is equipped
						transform.localEulerAngles = EquipRotation;
				}

		}
}
