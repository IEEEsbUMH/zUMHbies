using UnityEngine;
using System.Collections;

public class SwitchableDoor : MonoBehaviour, ISwitchable
{
		public bool Open;
	
		private HingeJoint myJoint;
		private JointMotor motor;
		private float defaultJointVelocity;
	
		// Use this for initialization
		public void Start ()
		{
				myJoint = GetComponent<HingeJoint> ();
				defaultJointVelocity = myJoint.motor.targetVelocity;
				motor = myJoint.motor;
				constrain ();
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				if (myJoint.useMotor) {
						if (Open && Mathf.Abs (transform.rotation.eulerAngles.y - 90) < 0.1)
								myJoint.useMotor = false;
						if (!Open && Mathf.Abs (transform.rotation.eulerAngles.y) < 0.1) {
								myJoint.useMotor = false;
								constrain ();
						}
				}
		}
	
		public void _Activate ()
		{
				Open = !Open;
				motor.targetVelocity = defaultJointVelocity * (Open ? 1 : -1);
				myJoint.motor = motor;
				myJoint.useMotor = true;
			
				if (Open)
						constrain ();
		}	
	
		void constrain ()
		{
				//So the door can't be pushed around while closed
				if (Open)
						rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
				else
						rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
		}
}
