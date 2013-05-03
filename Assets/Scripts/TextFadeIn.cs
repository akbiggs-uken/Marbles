using UnityEngine;
using System.Collections;

public class TextFadeIn : MonoBehaviour {
	
	public float fadeSpeed = 1.0f;
	float Alpha {
		get { return guiText.material.color.a; }
		set {
			Color matColor = guiText.material.color;
			guiText.material.color = new Color(matColor.r, matColor.g, matColor.b, value);
		}
	}
	
	// Use this for initialization
	void Start () {
		Alpha = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Alpha != 1) {
			Alpha = Mathf.Lerp(Alpha, 1, Time.deltaTime * fadeSpeed);
		}
	}
}
