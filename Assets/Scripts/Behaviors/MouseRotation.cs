using UnityEngine;
using System.Collections;

/// <summary>
/// Rotate the object according to the mouse's movement.
/// </summary>
public class MouseRotation : MonoBehaviour {
	
	// how much change movements in the mouse will make on the rotation
	const float INFLUENCE = 20.0f;
	const float ROTATION_SPEED = 2.0f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// normalize mouse coordinates
		float halfWidth = Screen.width/2;
		float rotateZ = (Input.mousePosition.x - halfWidth)/halfWidth * INFLUENCE;
		float halfHeight = Screen.height/2;
		float rotateX = (Input.mousePosition.y - halfHeight)/halfHeight * INFLUENCE * -1;
		
		Quaternion nextRotation = Quaternion.Euler(rotateX, 0, rotateZ);
		transform.rotation = Quaternion.Slerp(transform.rotation, nextRotation, 
			Time.deltaTime*ROTATION_SPEED);
	}
}
