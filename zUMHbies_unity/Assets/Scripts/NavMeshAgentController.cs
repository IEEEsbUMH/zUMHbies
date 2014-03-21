using UnityEngine;
using System.Collections;

public class NavMeshAgentController : MonoBehaviour
{
		public Transform Destination;

		// Use this for initialization
		void Start ()
		{
				GetComponent<NavMeshAgent> ().SetDestination (Destination.position);
		}

}
