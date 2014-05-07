using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour
{
		protected StatsControl statsControl;

		public Transform SpawnContainer;
		protected List<Transform> selectedSpawns;

		public void Awake ()
		{
				statsControl = GetComponent<StatsControl> ();
		}

		public void Start ()
		{
				selectedSpawns = new List<Transform> ();
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
		public GameObject BasicZombie;
		public GameObject GiantZombie;
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
				selectedSpawns = new List<Transform> ();
				for (int i=0; i<ZombiesPerWave[Wave-1]; i++) {
						GameObject zombie = Random.Range (0, 3) < 2 ? BasicZombie : GiantZombie;
						Instantiate (zombie, selectRandomSpawn ().position, Quaternion.identity);
						zombiesOnStage++;
				}
		}

		Transform selectRandomSpawn ()
		{
				int randomInt = Random.Range (0, SpawnContainer.childCount);
				Transform spawn = SpawnContainer.GetChild (randomInt);
				
				if (selectedSpawns.Count >= SpawnContainer.childCount) {
						selectedSpawns = new List<Transform> ();
				}

				while (selectedSpawns.Contains(spawn)) {
						
						randomInt = randomInt < SpawnContainer.childCount ? randomInt + 1 : 0;
						spawn = SpawnContainer.GetChild (randomInt);
				}

				selectedSpawns.Add (spawn);
				return spawn;
		}
}
