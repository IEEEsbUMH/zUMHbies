using UnityEngine;
using System.Collections;

public class MenuControllerB : MonoBehaviour
{

		public GameObject[] SelectableGameobjects;
		public TextMesh OculusTextMesh;
		public float MovementSpeed;
		public float EndRotation;
		public float EndX;

		private int selectedIndex {
				get {
						return h_selIn;
				}
				set {
						//print (value);
						if (value < 0)
								h_selIn = SelectableGameobjects.Length - 1;
						else if (value > SelectableGameobjects.Length - 1)
								h_selIn = 0;
						else
								h_selIn = value;
				}
		}
		private int h_selIn;

		// Use this for initialization
		void Start ()
		{
				selectedIndex = 0;
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
						selectedIndex--;
				}

				if (Input.GetKeyDown (KeyCode.DownArrow)) {
						selectedIndex++;
				}

				if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown (KeyCode.Space)) {
						switch (selectedIndex) {
						case 0:
								Application.LoadLevel ("Game");
								break;

						case 1:
								OVR_Helper.UsingOVR = !OVR_Helper.UsingOVR;
								OculusTextMesh.text = OVR_Helper.UsingOVR ? "Oculus VR: ON" : "Oculus VR: OFF";
								break;
						}
				}
		}

		void FixedUpdate ()
		{
				for (int i=0; i<SelectableGameobjects.Length; i++) {
						Transform b_transf = SelectableGameobjects [i].transform;
						if (i == selectedIndex) {
								b_transf.position = new Vector3 (Mathf.Lerp (b_transf.position.x, EndX, MovementSpeed * Time.deltaTime), b_transf.position.y, b_transf.position.z);
								b_transf.rotation = Quaternion.Euler (new Vector3 (0, Mathf.Lerp (b_transf.rotation.eulerAngles.y, EndRotation, MovementSpeed * Time.deltaTime)));
						} else {
								b_transf.position = new Vector3 (Mathf.Lerp (b_transf.position.x, 0, MovementSpeed * Time.deltaTime), b_transf.position.y, b_transf.position.z);
								b_transf.rotation = Quaternion.Euler (new Vector3 (0, Mathf.Lerp (b_transf.rotation.eulerAngles.y, 0, MovementSpeed * Time.deltaTime)));
						}
				}
		}
}
