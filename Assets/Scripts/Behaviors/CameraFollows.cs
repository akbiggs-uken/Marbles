using UnityEngine;
using System.Collections;

public class CameraFollows : MonoBehaviour {
	
	public Vector3 offset = new Vector3(0, 35, -25);
	public float followSpeed = 1f;
	
	GameObject cameraFollowing;
	
	// Use this for initialization
	void Start () {
		cameraFollowing = GameLogicHelper.FindCamera();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = new Vector3(transform.position.x + offset.x,
		transform.position.y + offset.y, transform.position.z + offset.z);
		
		// ease the camera towards the player
		cameraFollowing.transform.position = Vector3.MoveTowards(cameraFollowing.transform.position,
			targetPos, followSpeed);
	}
}
