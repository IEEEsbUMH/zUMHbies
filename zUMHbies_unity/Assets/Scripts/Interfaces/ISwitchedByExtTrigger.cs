using UnityEngine;
using System.Collections;

public interface ISwitchedByExtTrigger
{
		void _TriggerEnterSwitch (int a_index, Collider a_collider); //The idea is that these functions can be triggered by multiple triggers with ExternalTriggerBehaviour, each with different indexes
		void _TriggerStaySwitch (int a_index, Collider a_collider);
		void _TriggerExitSwitch (int a_index, Collider a_collider);
}
