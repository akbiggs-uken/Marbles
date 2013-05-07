using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class Main : MonoBehaviour {
	
	Level curLevel;
	ArrayList levelNames = new ArrayList() {
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
			if (curLevel && HaveMoreLevels()) {
				LoadNextLevel();
			} else if (!PlayerWon(curLevel)) {
				RestartLevel();
			} else // no more levels
				EndGame();
		}
	}
	
	bool IsDone(Level level) {
		
	}
	
	bool PlayerWon(Level level) {
		
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
		string nextLevelName = levels.Pop();
		curLevel = Level.LoadFromSceneName(nextLevelName);
	}
	
	void RestartLevel() {
		Application.LoadLevel(curLevel);
	}
	
	void EndGame() {
		Application.Quit();
	}
}
