using UnityEngine;
using System.Collections;

public class DestroyTap_Water : MonoBehaviour {
	private int TimeDestroy=9;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, TimeDestroy);
	}
}
