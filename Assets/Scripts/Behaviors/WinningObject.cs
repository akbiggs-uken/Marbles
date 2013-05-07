using UnityEngine;
using System.Collections;

public class WinningObject : MonoBehaviour {
	
	const float WINNING_OFFSET = 30f;
	const float LOSING_OFFSET = -20f;
	
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
		// TODO: Don't crash when there are no platforms.
		float lowestHeightWithoutLoss = GameLogicHelper.FindLowestPlatformHeight().Value;
		float highestHeightWithoutWin = GameLogicHelper.FindHighestPlatformHeight().Value;

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
