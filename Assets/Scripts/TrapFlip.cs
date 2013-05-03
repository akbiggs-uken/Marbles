using UnityEngine;
using System.Collections;

public class TrapFlip : MonoBehaviour {
	
	#region Constants
	const float EPSILON = 0.0001f;
	#endregion
	
	#region Members
	public Vector3 flipRotation = new Vector3(270, 0, 0);
	public float flipInterval = 6f;
	public float flipSpeed = 1f;
		
	float flipTimer;
	bool flipping = false;
	Vector3 rotationTarget = new Vector3(0, 0, 0);
	Vector3 pivot;
	#endregion
	
	// Use this for initialization
	void Start () {
		ResetTimer();
		pivot = new Vector3(transform.position.x + transform.lossyScale.x/2, transform.position.y,
			transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		flipTimer = flipTimer + Time.deltaTime;
		
		// flip every once in a while
		if (flipTimer + Time.deltaTime >= flipInterval) {
			Flip();
			ResetTimer();
		}
		
		// if we've got to rotate, we've got to rotate.
		if (Quaternion.Euler(rotationTarget) != transform.localRotation) {
			
			// TODO: Debug rotating around back of trap panel.
			
			/*// figure out how much we should rotate by for things to look smooth. 
			float currentRotateAngle = transform.localRotation.eulerAngles.x;
			float targetAngle = Quaternion.Euler(rotationTarget).eulerAngles.x;
			float angleTransition = Mathf.Lerp(currentRotateAngle, targetAngle, Time.deltaTime * flipSpeed);
			
			transform.RotateAround(pivot, Vector3.back, targetAngle);
			
			// trying to avoid floating point rounding issues
			if (Vector3.Distance(rotationTarget, transform.localRotation.eulerAngles) < EPSILON) {
				transform.localRotation = Quaternion.Euler (rotationTarget);
			}*/
			
			transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(rotationTarget), Time.deltaTime * flipSpeed);
		}
	}
	
	void ResetTimer() {
		flipTimer = 0;
	}
	
	void Flip() {
		flipping = !flipping;
		rotationTarget = flipping ? flipRotation : new Vector3(0, 0, 0);
	}
}
