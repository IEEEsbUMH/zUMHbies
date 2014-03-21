using UnityEngine;
using System.Collections;

public class GeneralPickableBehaviour : MonoBehaviour, IInteractive, IPickable
{		
		//Members
		public int Size;
		public string Name;
		public Texture2D Picture;

		public Material OutlinedMaterial;
		public int OutlinedMaterialIndex;
		public Renderer RendererTarget;
		private Material originalMaterial;

		public Vector3 DropRotation; //Rotation in euler angles, will be converted to quaternion when asked for _DropRotation
		public Vector3 EquipRotation; //Same

		//IPickable members
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

		//IInteractive members
		public Material _OutlinedMaterial {
				get {
						return OutlinedMaterial;
				}
		}
		public int _OutlinedMaterialIndex {
				get {
						return OutlinedMaterialIndex;
				}
		}

		public Renderer _RendererTarget {
				get {
						if (RendererTarget != null)
								return RendererTarget;
						else if (renderer != null)
								return renderer;
						else {
								print ("Warning: " + name + " does not have any renderer to be returned!");
								return null;
						}
				}
		}

		protected virtual void Start ()
		{
				originalMaterial = _RendererTarget.materials [OutlinedMaterialIndex];
		}

		public virtual void _Activate ()
		{
				print (Name + " has been activated");
		}

		public virtual void _SetAsActiveIInteractive (bool a_active)
		{
				if (_RendererTarget == null)
						return;

				Material[] t_newMaterialsArray = _RendererTarget.materials;
				if (a_active) {
						t_newMaterialsArray [OutlinedMaterialIndex] = OutlinedMaterial;
				} else 
						t_newMaterialsArray [OutlinedMaterialIndex] = originalMaterial;
		
				_RendererTarget.materials = t_newMaterialsArray;
		}

		public virtual void _BeUsed ()
		{
				//Do somthing for the player
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

				transform.parent = a_parent;
		
				transform.localPosition = a_coordinates;
				rigidbody.isKinematic = a_beKinematic;
				collider.isTrigger = a_beKinematic;

				//No parent, so the pickable is dropped
				if (a_parent == null) {
						transform.localEulerAngles = DropRotation;
						gameObject.layer = Layers.DEFAULT;
						collider.enabled = true; //In case the collider is still disabled;
				} else {//Parented, so the pickable is equipped
						transform.localEulerAngles = EquipRotation;
						gameObject.layer = Layers.ITEMS_IN_HANDS;
						collider.enabled = false;
				}

		}
}
