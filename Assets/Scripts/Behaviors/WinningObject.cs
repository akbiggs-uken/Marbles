using UnityEngine;
using System.Collections;

public class WinningObject : MonoBehaviour {
	
	const float WINNING_HEIGHT = 30f;
	const float LOSING_HEIGHT = -20f;
	const float OFF_TOP_HEIGHT = 40f;
	const float OFF_BOTTOM_HEIGHT = -300f;
	
	bool wonLevel = false;
	bool lostLevel = false;
	
	bool LevelOver {
		get { return (wonLevel || lostLevel); }
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// win the level if the object goes beyond a certain height,
		// or lose when it goes below a different height
		if (transform.position.y >= WINNING_HEIGHT) {
			WinLevel();
			
			// don't want the object to be destroyed in plain view, so wait a bit
			if (transform.position.y >= OFF_TOP_HEIGHT)
				Destroy(gameObject);
		} else if (transform.position.y <= LOSING_HEIGHT) {
			LoseLevel();
			if (transform.position.y <= OFF_BOTTOM_HEIGHT)
				Destroy(gameObject);
		}
	}
	
	void WinLevel() {
		// only win once
		if (!LevelOver) {
			Debug.Log("YOU WON!");
			wonLevel = true;
		}
	}
	
	void LoseLevel() {
		// only lose once
		if (!LevelOver) {
			Debug.Log("YOU LOST...");
			lostLevel = true;
		}
	}
}
