using UnityEngine;
using System.Collections;

public class Tap_Water: GeneralInteractiveBehaviour{
	
	// C#
	// Instantiates a prefab in a circle
	public Transform prefab;
	public Transform Empty;
	public int ModifierTime=6;
	private int i=0;
	public override void _Activate (){
	if (i<1){
	Instantiate(prefab, Empty.position, Quaternion.identity);
			StartCoroutine(TestCoroutine());
			i++;
	}
			
	}
	IEnumerator TestCoroutine(){
						yield return new WaitForSeconds (ModifierTime);
						i--;
	}
	}
