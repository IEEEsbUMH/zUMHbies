using UnityEngine;
using System.Collections;

public class StatsControl : MonoBehaviour
{
		public GUICamerabehaviour GUICamB;

		public GUIText ScoreGUI;

		protected int score;
		public int Score {
				get {
						return score;
				}
				set {
						score = value;
						ScoreGUI.text = "Puntos: " + score;
						GUICamB.RenderScene = true;
				}
		}
}
