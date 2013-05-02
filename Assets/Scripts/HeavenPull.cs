using UnityEngine;
using System.Collections;

public class HeavenPull : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.name == "Marble")
			EndLevel();
		
		
	}
	
	void EndLevel() {
	
	}
}
