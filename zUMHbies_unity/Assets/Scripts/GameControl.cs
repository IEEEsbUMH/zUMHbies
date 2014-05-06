using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
		protected StatsControl statsControl;

		public void Awake ()
		{
				statsControl = GetComponent<StatsControl> ();
		}

		public void EndGame ()
		{
				GetComponent<GlobalSoundControl> ().PlayDeathSound ();
		}

		public void AddScore (int a_score)
		{
				statsControl.Score += a_score;
		}

		//Spawn control
		public float SecondsBetweenWaves;
		protected int zombiesOnStage;
		[HideInInspector]
		public int
				ZombiesOnStage {
				get {
						return zombiesOnStage;
				}
				set {
						zombiesOnStage = value;
						if (value == 0)
								Invoke ("startNextWave", SecondsBetweenWaves);
				}
		}
		public int[] ZombiesPerWave;
		[HideInInspector]
		public int
				Wave;

		void startNextWave ()
		{
				Wave++;
		}


}
