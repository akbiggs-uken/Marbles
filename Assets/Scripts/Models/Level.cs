using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Level
	{
		#region Members
		String name;
		CompletionStatus status;
		GameObject container;
		#endregion
		
		private Level(String name, GameObject container) {
			this.name = name;
			this.container = container;
			this.status = CompletionStatus.NotComplete;
		}
		
		public static Level CreateAndLoad(String name) {
			Application.LoadLevel(name);
			GameObject container = GameLogicHelper.FindLevel();
			return new Level(name, container);
		}
		
		public void Update() {
			UpdateCompletionStatus();
		}
		
		void UpdateCompletionStatus() {
			
		}
		
		public string Name {
			get { return name; }
		}
		
		public bool IsLoaded {
			get { return container != null; }
		}
		
		public bool IsComplete {
			get { return status != CompletionStatus.NotComplete; }
		}
		
		public bool PlayerWon {
			get { return status == CompletionStatus.PlayerWon; }
		}
	}
	
	public enum CompletionStatus {
		PlayerWon,
		PlayerLost,
		NotComplete,
		NotLoaded
	}
}

