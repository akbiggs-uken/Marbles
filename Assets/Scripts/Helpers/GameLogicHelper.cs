using UnityEngine;
using System.Collections;

public static class GameLogicHelper {
	
	public static GameObject FindPlayer() {
		return GameObject.Find("Marble");
	}
	
	public static GameObject FindCamera() {
		return GameObject.Find ("Camera");
	}
	
	public static GameObject FindLevel() {
		return GameObject.Find ("Level");
	}
	
	public static float? FindLowestPlatformHeight() {
		GameObject platforms = GameObject.Find ("Platforms");
		float lowestHeight = float.MaxValue;
		
		foreach (var platform in platforms.GetComponentsInChildren<Transform>()) {
			var height = platform.transform.position.y;
			if (height < lowestHeight)
				lowestHeight = height; 
		}
		
		// return null if no platforms
		if (lowestHeight == float.MaxValue)
			return null;
		else
			return lowestHeight;
	}
	
	public static float? FindHighestPlatformHeight() {
		GameObject platforms = GameObject.Find ("Platforms");
		float highestHeight = float.MinValue;
		
		foreach (var platform in platforms.GetComponentsInChildren<Transform>()) {
			var height = platform.transform.position.y;
			if (height > highestHeight)
				highestHeight = height; 
		}
		
		// return null if no platforms
		if (highestHeight == float.MaxValue)
			return null;
		else
			return highestHeight;
	}
	
	public static bool IsPlayer(Collider collider) {
		return collider.name == "Marble";
	}
}
