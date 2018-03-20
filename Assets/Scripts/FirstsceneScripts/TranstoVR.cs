using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TranstoVR : MonoBehaviour {

	public FadeInScript fadein;
	public bool fadebl = false;
	// Use this for initialization
	void Start () {
		Button btn = this.GetComponent<Button> ();
		btn.onClick.AddListener (OnClick);
	}

	private void OnClick(){
		fadebl = true;
		BoolVrandphone.IsVR = true;
	}

	// Update is called once per frame
	void Update () {
		if (fadebl) {
			if (fadein.fadeOut ())
				SceneManager.LoadScene ("MasterRoom");

		}
	}
}
