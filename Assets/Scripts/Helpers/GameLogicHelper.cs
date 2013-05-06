using UnityEngine;
using System.Collections;

public static class GameLogicHelper {
	
	public static bool IsPlayer(Collider collider) {
		return collider.name == "Marble";
	}
}
