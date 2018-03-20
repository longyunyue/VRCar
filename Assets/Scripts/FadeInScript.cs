using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour {

	public Image background;
	public float a;
	public float b;
	void awake(){
		a = 1f;
		b = 0;
	}

	// Use this for initialization
	public void fadeIn(){
	   if (a > 0) {
			a -= 0.02f;
		}
		background.color = new Color(0f,0f,0f,a);
	}
	public bool fadeOut(){
		
		if (b < 0.80f) {
			b += 0.02f;
			background.color = new Color (0f, 0f, 0f, b);
			return false;
		} else if (b >= 0.80f && b < 0.99f) {
			b += 0.02f;
			background.color = new Color (0f, 0f, 0f, b);
			return true;
		} 
		else {
			background.color = new Color (0f, 0f, 0f, b);
			return true;
		}
	}

}
