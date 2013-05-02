using UnityEngine;
using System.Collections;

public class WinningObject : MonoBehaviour {
	
	const float WINNING_HEIGHT = 23f;
	const float LOSING_HEIGHT = -20f;
	const float OFF_TOP_HEIGHT = 40f;
	const float OFF_BOTTOM_HEIGHT = -300f;
	
	bool wonGame = false;
	bool lostGame = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y >= WINNING_HEIGHT) {
			WinLevel();
			if (transform.position.y >= OFF_TOP_HEIGHT)
				Destroy(gameObject);
		} else if (transform.position.y <= LOSING_HEIGHT) {
			LoseLevel();
			if (transform.position.y <= OFF_BOTTOM_HEIGHT)
				Destroy(gameObject);
		}
		
	}
	
	void WinLevel() {
		if (!(wonGame || lostGame)) { 
			Destroy(gameObject);
			Debug.Log ("YOU WON!");
		}
	}
	
	void LoseLevel() {
		if (!(lostGame || wonGame)) {
			Debug.Log("YOU LOST...");
			lostGame = true;
		}
	}
}
