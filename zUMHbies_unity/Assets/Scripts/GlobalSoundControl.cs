using UnityEngine;
using System.Collections;

public class GlobalSoundControl : MonoBehaviour
{
		public AudioSource[] AudioSources;

		public AudioClip[] AtmosphereClips;

		public AudioClip[] TensionClips;

		public AudioClip NoMercy;
		
		[Range(0.1f, 1f)]
		public float fadeSteps;

		private int currentAudioSource;

		private AudioClip[] CurrentTheme;

		private bool switchingTheme;

		void Start () 
		{
			currentAudioSource = 0;
			switchingTheme = false;
			CurrentTheme = AtmosphereClips;
			PlayNextClip();
		}
	
		void Update()
		{
			if(switchingTheme == true)
			{				
				if (AudioSources[currentAudioSource].volume < 1) 
				{	
					FadeIn();
				}
				if (AudioSources[getSecondaryAudioSource()].volume > 0.1) 
				{
					FadeOut();
				} else {
					AudioSources[getSecondaryAudioSource()].Stop();
					switchingTheme = false;
					setDefaultVolumes();
				}
			} else {
				if(!AudioSources[currentAudioSource].isPlaying) 
				{
					SetCurrentAudioSource();
					PlayNextClip();
				}
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
			AudioSources[currentAudioSource].clip = CurrentTheme[Random.Range(0,CurrentTheme.Length)];
			AudioSources[currentAudioSource].loop = false;
			AudioSources[currentAudioSource].Play();
		}

		private void PlayClip (int clip, AudioClip[] theme)
		{
			AudioSources[currentAudioSource].clip = theme[clip];
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

		private int getSecondaryAudioSource ()
		{
			if(currentAudioSource == 0)
			{
				return 1;
			}
			else
			{
				return 0;
			}
		}

		private void setSwitchingVolumes()
		{
			AudioSources[currentAudioSource].volume = (float)0.1;
			AudioSources[getSecondaryAudioSource()].volume = (float)1;
		}

		private void setDefaultVolumes()
		{
			AudioSources[currentAudioSource].volume = (float)1;
			AudioSources[getSecondaryAudioSource()].volume = (float)1;
		}

		private void FadeIn ()
		{
			AudioSources[currentAudioSource].volume += ((float)fadeSteps) * Time.deltaTime;
			print("Fade in:" + AudioSources[currentAudioSource].volume);
		}

		private void FadeOut ()
		{
			AudioSources[getSecondaryAudioSource()].volume -= ((float)fadeSteps) * Time.deltaTime;
			print("Fade out:" + AudioSources[getSecondaryAudioSource()].volume);
		}

		private void ChangeAudioSource()
		{
		}

		private void changeTheme(AudioClip[] theme)
		{
			switchingTheme = true;
			CurrentTheme = theme;
			SetCurrentAudioSource();
			setSwitchingVolumes();
			PlayNextClip();
		}

		public void ChangeToTension ()
		{
			changeTheme(TensionClips);			
		}

		public void ChangeToAtmosphere ()
		{
			changeTheme(AtmosphereClips);
		}

}
