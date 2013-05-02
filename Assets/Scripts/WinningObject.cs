using UnityEngine;
using System.Collections;

public class WinningObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 20) {
			WinLevel();
		}
	}
	
	void WinLevel() {
		Destroy(gameObject);
		Debug.Log ("YOU WON!");
	}
}
