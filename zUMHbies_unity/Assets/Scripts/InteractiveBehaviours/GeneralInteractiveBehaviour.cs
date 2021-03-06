﻿using UnityEngine;
using System.Collections;

public class GeneralInteractiveBehaviour : MonoBehaviour, IInteractive
{
		public Material OutlinedMaterial;
		public int OutlinedMaterialIndex;
		public Renderer RendererTarget;

		private Material originalMaterial;

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
						//print (gameObject);
						if (RendererTarget != null)
								return RendererTarget;
						else if (renderer != null) {
								
								return renderer;
						} else {
								Debug.LogWarning ("Warning: " + name + " does not have any renderer to be returned!");
								return null;
						}
				}
		}

		protected virtual void Start ()
		{
				if (_RendererTarget != null)
						originalMaterial = _RendererTarget.materials [OutlinedMaterialIndex];
		}

		public virtual void _Activate ()
		{
				//Do something
		}

		public virtual void _SetAsActiveIInteractive (bool a_active)
		{
				//print (this);
				if (_RendererTarget == null)
						return;

				Material[] t_newMaterialsArray = _RendererTarget.materials;
				if (a_active) {
						t_newMaterialsArray [OutlinedMaterialIndex] = OutlinedMaterial;
				} else 
						t_newMaterialsArray [OutlinedMaterialIndex] = originalMaterial;
		
				_RendererTarget.materials = t_newMaterialsArray;
		}
}