using UnityEngine;
using System.Collections;

public class MenuMusicBackground : MonoBehaviour {
	
	public AudioSource clip;
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (!clip.isPlaying) {
			clip.Play ();
		}
		
	}
}
