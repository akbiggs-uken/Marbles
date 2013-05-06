using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class LaunchOnContact : MonoBehaviour {
	
	public Vector3 launchDirection = new Vector3(0, 1, 0);
	public float launchSpeed = 15f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter(Collision collision) {
		// guaranteed to be non-empty by function precondition
		ContactPoint contact = collision.contacts[0];
		if (GameLogicHelper.IsPlayer(contact.otherCollider))
			Launch(contact.otherCollider);
	}
	
	
	void Launch(Collider objToLaunch) {
		objToLaunch.rigidbody.velocity = launchDirection.normalized.ScalarMultiply(launchSpeed);
	}
}
