﻿using UnityEngine;
using System.Collections;

public class ContainedPhysicsBehaviour : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
	
		}
	
		public void SetFree ()
		{
				transform.parent = transform.parent.parent; //Transform goes up one level in the hierarchy

				if (rigidbody != null)
						rigidbody.isKinematic = false;
				else
						print ("Warning: GameObject " + name + " does not have a rigidbody attached");

				if (collider != null)
						collider.enabled = true;
				else
						print ("Warning: GameObject " + name + " does not have a collider attached");
		}
}