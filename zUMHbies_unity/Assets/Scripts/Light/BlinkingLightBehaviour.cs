using UnityEngine;
using System.Collections;

public class BlinkingLightBehaviour : MonoBehaviour
{
		public Light LightToBlink;

		public Renderer EmissiveRenderer; //Can be left as null
		public Material EmissiveMaterial;
		public int MaterialIndex;
		private Material originalMaterial;
		private Renderer rendererToUse;

		public float OnTime;
		public float OffTime;
		public float BlinkingTime;
		public float BlinkFrequency;
		public float BlinkingIntensityFactor;

		public bool AutoStart;

		private float originalIntensity;
	
		void Start ()
		{
				originalIntensity = LightToBlink.intensity;


				//Selects renderer it will use to change the material
				if (EmissiveRenderer != null)
						rendererToUse = EmissiveRenderer;
				else if (renderer != null)
						rendererToUse = renderer;

				if (rendererToUse != null) {
						originalMaterial = rendererToUse.materials [MaterialIndex];
						if (rendererToUse == null)
								print ("Warning: " + name + " has no renderer attach it emissive material to!");
				}

				if (AutoStart) {
						StartBlinking ();
				}
		}

		public void StartBlinking ()
		{
				StartCoroutine ("work");
		}

		public void StopBlinking (bool a_leaveOff=true)
		{
				StopCoroutine ("work");
		}

		IEnumerator work ()
		{
				while (true) {
						//Light on
						switchLight (true);
						yield return new WaitForSeconds (OnTime);

						//Light blinking
						float t_timePerBlink = 1 / BlinkFrequency;
						float t_totalBlinks = BlinkingTime / t_timePerBlink;

						int i = 0;
						LightToBlink.intensity = originalIntensity * BlinkingIntensityFactor;
						while (i++<=t_totalBlinks) {
								switchLight (!LightToBlink.enabled);
								yield return new WaitForSeconds (t_timePerBlink);
						}

						//Light off
						switchLight (false);
						LightToBlink.intensity = originalIntensity;
						yield return new WaitForSeconds (OffTime);
				}
		}

		void switchLight (bool a_state)
		{
				LightToBlink.enabled = a_state;
				if (rendererToUse != null && EmissiveMaterial != null) {
						Material[] t_materials = rendererToUse.materials;
						t_materials [MaterialIndex] = a_state ? EmissiveMaterial : originalMaterial;
						rendererToUse.materials = t_materials;
				}
		}
}
