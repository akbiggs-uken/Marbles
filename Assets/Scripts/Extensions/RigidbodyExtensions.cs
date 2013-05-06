using UnityEngine;
using System.Collections;

public static class RigidbodyExtensions {
	public static Vector3 GetLocalVelocity(this Rigidbody body) {
		return body.transform.InverseTransformDirection(body.velocity);
	}
	
	public static void SetLocalVelocity(this Rigidbody body, Vector3 newVelocity) {
		body.velocity = body.transform.TransformDirection(newVelocity);
	}
}
