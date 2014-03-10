using UnityEngine;
using System.Collections;

public class bloodSplash : MonoBehaviour
{
	public float splashTime;
	public GameObject splatterTexture;
	public int splatterNumberLimit;
	private int x;
	public void InstantiateSplatter (ParticleSystem.CollisionEvent hit) 
	{	
		while (x < splatterNumberLimit)
		{
			var splatter = Instantiate (splatterTexture, (hit.intersection + (hit.normal * 0.1f)), Quaternion.FromToRotation (Vector3.up, hit.normal)) as GameObject;
			
			var scaler = Random.value;
			Vector3 vt3 = splatter.transform.localScale;
			vt3.x *= scaler;
			vt3.z *= scaler;
			splatter.transform.localScale = vt3;
			
			var rater = Random.Range (0, 359);
			splatter.transform.RotateAround (hit.intersection, hit.normal, rater);
			splatter.transform.parent = transform.parent;
			Destroy (splatter, splashTime);
			x++;
		}   
		x = 0;
	}
	public void OnParticleCollision(GameObject other) 
	{
		var collisionEvents = new ParticleSystem.CollisionEvent[16];
		
		// adjust array length
		var safeLength = particleSystem.safeCollisionEventSize;
		if (collisionEvents.Length < safeLength) {
			collisionEvents = new ParticleSystem.CollisionEvent[safeLength];
		}
		
		
		// get collision events for the gameObject which script is attached to
		var numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);
		
		
		// apply texture for each collision
		x = 0;
		for (var i = 0; i < numCollisionEvents; i++) {
			if(i%2 == 0) {InstantiateSplatter (collisionEvents[i]);}
		}
	}
}

