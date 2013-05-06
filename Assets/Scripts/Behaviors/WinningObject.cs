using UnityEngine;
using System.Collections;

public class WinningObject : MonoBehaviour {
	
	const float WINNING_OFFSET = 30f;
	const float LOSING_OFFSET = -20f;
	
	bool wonLevel = false;
	bool lostLevel = false;
	
	float lowestHeightWithoutLoss;
	float highestHeightWithoutWin;
	
	bool LevelOver {
		get { return (wonLevel || lostLevel); }
	}
	// Use this for initialization
	void Start () {
		// TODO: don't crash with no platforms
		lowestHeightWithoutLoss = GameLogicHelper.FindLowestPlatformHeight().Value;
		highestHeightWithoutWin = GameLogicHelper.FindHighestPlatformHeight().Value;
	}
	
	// Update is called once per frame
	void Update () {
		
		// win the level if the object goes beyond a certain height,
		// or lose when it goes below a different height
		if (transform.position.y >= highestHeightWithoutWin + WINNING_OFFSET) {
			WinLevel();
		} else if (transform.position.y <= lowestHeightWithoutLoss + LOSING_OFFSET) {
			LoseLevel();
		}
	}
	
	void OnBecameInvisible() {
		if (LevelOver)
			Destroy(gameObject);
		
	}
	
	void WinLevel() {
		// only win once
		if (!LevelOver) {
			Debug.Log("YOU WON!");
			wonLevel = true;
			StopCameraFollow();
			StopRotation();
		}
	}
	
	void LoseLevel() {
		// only lose once
		if (!LevelOver) {
			Debug.Log("YOU LOST...");
			lostLevel = true;
			StopCameraFollow();
			StopRotation();
		}
	}
	
	void StopCameraFollow() {
		if (GetComponent<CameraFollows>())
			Destroy (GetComponent<CameraFollows>());
	}
	
	void StopRotation() {
		GameObject level = GameLogicHelper.FindLevel();
		if (level.GetComponent<MouseRotation>() != null)
			Destroy(level.GetComponent<MouseRotation>());
	}
}
