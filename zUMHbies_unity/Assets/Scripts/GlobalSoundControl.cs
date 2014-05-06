using UnityEngine;
using System.Collections;

public class GlobalSoundControl : MonoBehaviour
{
		public AudioSource[] AudioSources;

		public AudioClip[] AtmosphereClips;

		public AudioClip[] TensionClips;

		public AudioClip NoMercy;

		private int currentAudioSource;

		private AudioClip[] CurrentTheme;

		void Start () 
		{
			currentAudioSource = 0;
			ChangeToAtmosphere();
			PlayNextClip(0);
		}
	
		void Update()
		{
			if(!AudioSources[currentAudioSource].isPlaying) 
			{
				ChangeToTension();
				PlayNextClip();
				
			}
		}

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

		private void PlayNextClip ()
		{
			SetCurrentAudioSource();
			AudioSources[currentAudioSource].clip = CurrentTheme[Random.Range(0,AtmosphereClips.Length)];
			AudioSources[currentAudioSource].loop = false;
			AudioSources[currentAudioSource].Play();
		}

		private void PlayNextClip (int clip)
		{
			SetCurrentAudioSource();
			AudioSources[currentAudioSource].clip = CurrentTheme[clip];
			AudioSources[currentAudioSource].loop = false;
			AudioSources[currentAudioSource].Play();
		}

		private void SetCurrentAudioSource ()
		{
			if(currentAudioSource == 0)
			{
				currentAudioSource = 1;
			}
			else
			{
				currentAudioSource = 0;
			}
		}

		private void FadeIn (AudioSource a_clip)
		{

		}

		private void FadeOut (AudioSource a_clip)
		{
			
		}

		private void ChangeAudioSource()
		{
			
		}

		public void ChangeToTension ()
		{
			CurrentTheme = TensionClips;
		}

		public void ChangeToAtmosphere ()
		{
			CurrentTheme = AtmosphereClips;
		}
}
