using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class Main : MonoBehaviour {
	
	Level curLevel;
	List<string> levelNames = new List<string> {
		"Basic",
		"Slopes",
		"Rushed"
	};
	
	// Use this for initialization
	void Start () {
		AssertLevelNamesAreValid();
		LoadNextLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
		// check the level status and react accordingly
		if (curLevel.IsComplete) {
			if (curLevel != null && HaveMoreLevels()) {
				LoadNextLevel();
			} else if (!PlayerWon(curLevel)) {
				RestartLevel();
			} else // no more levels
				EndGame();
		}
	}
	
	bool IsDone(Level level) {
		return true;	
	}
	
	bool PlayerWon(Level level) {
		return true;
	}
	
	bool HaveMoreLevels() {
		return levelNames.Count > 0;
	}
	
	void AssertLevelNamesAreValid() {
		foreach (string levelName in levelNames) {
			AssertLevelExists(levelName);
		}
	}
	
	void AssertLevelExists(string levelName) {
		DebugUtils.Assert(levelNames.Contains(levelName));
	}
	
	void LoadNextLevel() {
		string nextLevelName = levelNames.Pop<string>(0);
		curLevel = Level.CreateAndLoad(nextLevelName);
	}

	void RestartLevel() {
		Application.LoadLevel(curLevel.Name);
	}
	
	void EndGame() {
		Application.Quit();
	}
}
