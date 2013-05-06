using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LaunchOnContact : MonoBehaviour {
	
	public float launchSpeed = 15f;
	Vector3 launchDirection;
	
	// Use this for initialization
	void Start () {
		launchDirection = transform.up;
	}
	
	// Update is called once per frame
	void Update () {
		// change the launch direction as the launcher rotates
		launchDirection = transform.up;
	}
	
	void OnCollisionEnter(Collision collision) {
		// guaranteed to be non-empty by function precondition
		ContactPoint contact = collision.contacts[0];
		if (GameLogicHelper.IsPlayer(contact.otherCollider))
			Launch(contact.otherCollider);
	}
	
	
	void Launch(Collider objToLaunch) {
		objToLaunch.rigidbody.velocity = launchDirection.normalized * launchSpeed;
	}
}
