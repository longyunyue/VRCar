using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Transtophone : MonoBehaviour {
	public FadeInScript fadein;
	public bool fadebol = false;
	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button> ();
		btn.onClick.AddListener (OnClick);
	}

	private void OnClick(){
		fadebol = true;
		BoolVrandphone.IsPhone = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (fadebol) {
			if (fadein.fadeOut ())
				SceneManager.LoadScene ("MasterRoom");

		}
	}
}
