using UnityEngine;
using System.Collections;

public class BloodPSManager : MonoBehaviour
{
		public RealtimeBloodStains StainsManager;

		private ParticleSystem.CollisionEvent[] collisionEvents = new ParticleSystem.CollisionEvent[16];

		void OnParticleCollision (GameObject a_hitGO)
		{
				if (collisionEvents.Length < particleSystem.safeCollisionEventSize)
						collisionEvents = new ParticleSystem.CollisionEvent[particleSystem.safeCollisionEventSize];

				int t_eventNum = particleSystem.GetCollisionEvents (a_hitGO, collisionEvents);
				
				//print (a_hitGO);

				for (int i =0; i<t_eventNum; i++) {
						Vector3 b_position = collisionEvents [i].intersection;
						Vector3 b_normal = collisionEvents [i].normal;

						StainsManager.CreateStain (a_hitGO, b_position, b_normal);
				}
		}
}
