using UnityEngine;
using System.Collections;

public class EndController : MonoBehaviour
{

		public TextMesh MyTextMesh;
		public float FadeSpeed;

		// Use this for initialization
		void Start ()
		{
				MyTextMesh.color = new Color (MyTextMesh.color.r, MyTextMesh.color.g, MyTextMesh.color.b, 0);
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				MyTextMesh.color = new Color (MyTextMesh.color.r, MyTextMesh.color.g, MyTextMesh.color.b, MyTextMesh.color.a + FadeSpeed);
		}
}
