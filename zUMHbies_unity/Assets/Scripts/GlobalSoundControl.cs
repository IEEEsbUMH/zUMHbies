using UnityEngine;
using System.Collections;

public class GlobalSoundControl : MonoBehaviour
{
		public AudioSource[] AudioSources;

		public AudioClip NoMercy;

		public void PlayDeathSound ()
		{
				StartPlaying (NoMercy);
		}

		public void StartPlaying (AudioClip a_audioClip, bool a_loop = false)
		{
				foreach (AudioSource a_source in AudioSources) {
						if (!a_source.isPlaying) {
								a_source.clip = a_audioClip;
								a_source.loop = a_loop;
								a_source.Play ();
								return;
						}
				}
		}
}
