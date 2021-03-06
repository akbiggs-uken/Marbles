using UnityEngine;
using System.Collections;

public class HeavenPull : MonoBehaviour {
	
	const float PULL_SPEED = 25.0f;
	const float PULL_DRAG = 20f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (GameLogicHelper.IsPlayer(other))
			EndLevel();
		
		other.attachedRigidbody.velocity = transform.up * PULL_SPEED;
		other.attachedRigidbody.useGravity = false;
	}
	
	void EndLevel() {
	
	}
}
