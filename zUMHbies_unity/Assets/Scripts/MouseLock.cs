using UnityEngine;
using System.Collections;

public class MouseLock : MonoBehaviour
{

		// Use this for initialization
		void Start ()
		{
				Screen.lockCursor = true;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetButton ("UseLeft"))
						Screen.lockCursor = true;
		}
}
